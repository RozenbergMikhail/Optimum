//
// Copyright (c) 2014. All rights reserved.
//
// Author: Rozenberg Mikhail
//

using System;
using Sample.Contexts;
using Platform.System;
using Platform.Entities;
using Platform.Auth;
using Platform.UITree;
using Platform.Web.Auth;
using Sample.Auth;
using Sample.SampleTypes;
using Sample.AnotherTypes;
using Sample.YetAnotherTypes;
using Sample.Meetings;
using ClientApp.Output;
using ClientApp.ServiceResolvers;

namespace ClientApp
{
	internal class SampleController
	{
		private readonly ISampleContextProvider contextProvider;
		private readonly ICurrentUserTokenProvider currentUserTokenProvider;
		private readonly ISampleUserTokenFactory sampleUserTokenFactory;
		private readonly IConsoleProvider consoleProvider;
		
		// TODO: ASP.NET will instantiate this controller if a proper ControllerFactory is registered
		public SampleController(ISampleContextProvider contextProvider, ICurrentUserTokenProvider currentUserTokenProvider, ISampleUserTokenFactory sampleUserTokenFactory, IConsoleProvider consoleProvider)
		{
			this.contextProvider = contextProvider;
			this.currentUserTokenProvider = currentUserTokenProvider;
			this.sampleUserTokenFactory = sampleUserTokenFactory;
			this.consoleProvider = consoleProvider;
		}

		public void OperationWithEnvironmentContext()
		{
			var context = this.contextProvider.GetCurrentContext();
			consoleProvider.WriteLine("{0} + {1} = {2}", context.GetCurrentTimeUTC(), context.GetLocalTimeOffset(), context.GetCurrentTimeLocal());
		}

		public void OperationWithUserContext()
		{
			var context = this.contextProvider.GetCurrentUserContext(this.currentUserTokenProvider.GetCurrentUserToken(this.contextProvider.GetCurrentContext()));
			var user = context.GetCurrentUser<SampleUserData>();
			consoleProvider.WriteLine("{0} + {1} = {2} : {3}", context.GetCurrentTimeUTC(), context.GetLocalTimeOffset(), context.GetCurrentTimeLocal(), user);
		}

		public void OperationWithUserContext(int userId)
		{
			var token = this.sampleUserTokenFactory.CreateUserToken(this.contextProvider.GetCurrentContext(), userId);
			var context = this.contextProvider.GetCurrentUserContext(token);
			var user = context.GetCurrentUser<SampleUserData>();
			consoleProvider.WriteLine("{0} + {1} = {2} : {3}", context.GetCurrentTimeUTC(), context.GetLocalTimeOffset(), context.GetCurrentTimeLocal(), user);
		}

		public void OperationWithMeetingContext(int userId, int meetingId, string newMeetingName)
		{
			var token = this.sampleUserTokenFactory.CreateUserToken(this.contextProvider.GetCurrentContext(), userId);
			var context = contextProvider.GetMeetingContext(token, meetingId);
			context.AddCustomItem("newMeetingName", newMeetingName);

			consoleProvider.WriteLine("NewMeetingName:{0}", context.GetCustomItem("newMeetingName"));

			var user = context.GetCurrentUser<SampleUserData>();
			var meeting = context.GetCurrentMeeting();
			consoleProvider.WriteLine("{0} + {1} = {2} : {3}, {4}", context.GetCurrentTimeUTC(), context.GetLocalTimeOffset(), context.GetCurrentTimeLocal(), user, meeting);

			context.UpdateCurrentMeeting(new MeetingUpdateData()
			{
				Name = newMeetingName,
				StartTime = DateTime.Now.AddDays(-1).AddHours(1),
				EndTime = DateTime.Now.AddDays(-1).AddHours(2),
			});

			meeting = context.GetCurrentMeeting();
			consoleProvider.WriteLine("{0} + {1} = {2} : {3}, {4}", context.GetCurrentTimeUTC(), context.GetLocalTimeOffset(), context.GetCurrentTimeLocal(), user, meeting);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var context = ServiceUtil.GetContextProvider<ISampleContextProvider>().GetCurrentContext();

			var consoleProvider = ServiceUtil.GetService<IConsoleProvider>(context);
			
			// test output string provider with string transformers
			var outputStr = Strings.GetTransformedString(context, "MyResourceKey");
			consoleProvider.WriteLine(outputStr);

			outputStr = Strings.GetHtmlEncodedString("<span>aaa</span>");
			consoleProvider.WriteLine(outputStr);

			consoleProvider.WriteLine("================================================");
			
			// test service provider
			var userTokenProvider = ServiceUtil.GetService<IUserTokenProvider>(context);
			var loginData = (SampleUserToken)userTokenProvider.GetUserToken(context, new UserTokenRequestWithCredentials("aaa", "bbb"));
			consoleProvider.WriteLine(loginData.UserId.ToString());
			consoleProvider.WriteLine("================================================");

			// test error handling
			try
			{
				throw ServiceUtil.GetService<ISampleTypeSetProvider>(context).GetSampleTypeInstanceByName(context, "First name").GetTestErrorException(context);
			}
			catch (EntityException<SampleType, TestError> exc)
			{
				consoleProvider.WriteLine(Strings.GetHtmlEncodedTransformedString(context, exc.Info.GetDescription(context)), exc.Entity);
				consoleProvider.WriteLine(exc.ContextSnapshot.UTCTime + " " + exc.ContextSnapshot.LocalTimeOffset + " " + exc.ContextSnapshot.UICulture.LCID);
				consoleProvider.WriteLine(context.GetCurrentTimeUTC() + " " + context.GetLocalTimeOffset() + " " + context.GetCurrentUICulture().LCID);
			}
			catch (EntityException<SampleType> exc)
			{
				if (exc.GetInfoEntityType() == typeof(TestError))
				{
					consoleProvider.WriteLine(exc.GetInfo<TestError>().GetDescription(context), exc.Entity);
				}
				else
				{
					throw;
				}
			}
			catch (EntityException exc)
			{
				if (exc.GetEntityType() != typeof(SampleType) && exc.GetInfoEntityType() == typeof(TestError))
				{
					consoleProvider.WriteLine(exc.GetInfo<TestError>().GetDescription(context), exc.GetEntity<SampleType>());
				}
				else
				{
					consoleProvider.WriteLine(exc.GetInfo().GetObjectDescription(context), exc.GetEntity().GetObjectDescription(context));
					throw;
				}
			}

			consoleProvider.WriteLine("================================================");

			// test configuration provider
			var authCookieProperties = ServiceUtil.GetService<IAuthCookiePropertiesProvider>(context).GetAuthCookieProperties();
			consoleProvider.WriteLine("Auth cookie name: {0}", authCookieProperties != null ? authCookieProperties.Name : "!!!DEFAULT!!!");
			consoleProvider.WriteLine("================================================");

			// test structured entity providers
			var sampleTypes = ServiceUtil.GetService<ISampleTypeStructuredDataProvider>(context).ListSampleTypes(context);
			foreach (var sampleType in sampleTypes)
			{
				consoleProvider.WriteLine(sampleType.GetObjectDescription(context));
			}

			consoleProvider.WriteLine("================================================");

			var treeDisplayer = new TreeDisplayer(consoleProvider);

			var anotherTypesTree = ServiceUtil.GetService<IAnotherTypeStructuredDataProvider>(context).GetAnotherTypeStructuredData(context);
			anotherTypesTree.GetSidebarLikeTreeWithSeparators().TraverseDepth(treeDisplayer.DisplayTree);
			consoleProvider.WriteLine("================================================");

			var yetAnotherTypesTree = ServiceUtil.GetService<IYetAnotherTypeStructuredDataProvider>(context).GetYetAnotherTypeStructuredData(context);
			yetAnotherTypesTree.GetSidebarLikeTreeWithSeparators().TraverseDepth(treeDisplayer.DisplayTree);
			consoleProvider.WriteLine("================================================");

			var controller = new SampleController(
				ServiceUtil.GetService<ISampleContextProvider>(context),
				ServiceUtil.GetService<ICurrentUserTokenProvider>(context),
				ServiceUtil.GetService<ISampleUserTokenFactory>(context),
				ServiceUtil.GetService<IConsoleProvider>(context));

			controller.OperationWithEnvironmentContext();
			controller.OperationWithUserContext();
			controller.OperationWithUserContext(100);
			controller.OperationWithMeetingContext(100, 2, "NEW MEETING NAME");
			consoleProvider.WriteLine("================================================");

			consoleProvider.ReadKey();
		}

		private class TreeDisplayer
		{
			private readonly IConsoleProvider consoleProvider;

			public TreeDisplayer(IConsoleProvider consoleProvider)
			{
				this.consoleProvider = consoleProvider;
			}

			public void DisplayTree(IUITreeNode node, int depth)
			{
				consoleProvider.WriteLine("{0}{1}-- {2}", Indent(depth), node.GetNodeType(), node);
			}
		}

		static string Indent(int count)
		{
			return String.Empty.PadLeft(count);
		}
	}
}
