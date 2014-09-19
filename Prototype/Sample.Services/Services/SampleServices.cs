//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;
using Platform.Contexts;
using Platform.Development;
using Platform.Resx.Info;
using Platform.Services;
using Sample.AnotherTypes;
using Sample.Auth;
using Sample.Configuration.AnotherTypes;
using Sample.Configuration.SampleTypes;
using Sample.Configuration.YetAnotherTypes;
using Sample.Contexts;
using Sample.Delegates;
using Sample.Meetings;
using Sample.SampleTypes;
using Sample.YetAnotherTypes;

namespace Sample.Bundles.Services
{
	/// <summary>
	/// Defines bundle of web services
	/// </summary>
	public class SampleServices : ServiceBundleWrapper
	{
		private readonly ContextInitData contextInitData;
		private readonly string sampleFullSectionName;

		/// <summary>
		/// Creates new instance of <see cref="SampleServices"/>
		/// </summary>
		/// <param name="contextInitData">context init data</param>
		/// <param name="sampleFullSectionName">sample full section name</param>
		public SampleServices(ContextInitData contextInitData, string sampleFullSectionName)
		{
			if (contextInitData == null)
				throw new MemoryPointerIsNullException("contextInitData");

			if (sampleFullSectionName == null)
				throw new MemoryPointerIsNullException("sampleFullSectionName");

			this.contextInitData = contextInitData;
			this.sampleFullSectionName = sampleFullSectionName;
			InitializeBundle();
		}

		private void InitializeBundle()
		{
			// auth services
			var sampleUserTokenFactory = new SampleUserTokenFactory(this.contextInitData.UTCTimeProvider);
			var userTokenProvider = new SampleUserTokenProvider(sampleUserTokenFactory);
			var userDataProvider = new SampleUserDataProvider();
			var currentUserTokenProvider = new SampleCurrentUserTokenProvider();
			this.Bundle.AddService(typeof(ISampleUserTokenFactory), sampleUserTokenFactory);
			this.Bundle.AddService(typeof(IUserTokenProvider), userTokenProvider);
			this.Bundle.AddService(typeof(IUserDataProvider), userDataProvider);
			this.Bundle.AddService(typeof(ICurrentUserTokenProvider), currentUserTokenProvider);

			// delegate services
			var delegateProvider = new DelegateProvider();
			this.Bundle.AddService(typeof(IDelegateProvider), delegateProvider);

			// sample type services
			var sampleTypeTestErrorFactory = new TestErrorFactory(new ResxDescriptionProvider(Resx.SampleTypes.Resources.ResourceManager, "SampleType_TestError_Description"));
			var sampleTypeSetProvider = new SampleTypeSetProvider(sampleTypeTestErrorFactory);
			var sampleTypeStructureProvider = new ConfigFileSampleTypeStructureProvider(this.sampleFullSectionName);
			var sampleTypeStructuredDataProvider = new SampleTypeStructuredDataProvider(sampleTypeSetProvider, sampleTypeStructureProvider);
			this.Bundle.AddService(typeof(ISampleTypeSetProvider), sampleTypeSetProvider);
			this.Bundle.AddService(typeof(ISampleTypeStructureProvider), sampleTypeStructureProvider);
			this.Bundle.AddService(typeof(ISampleTypeStructuredDataProvider), sampleTypeStructuredDataProvider);

			// another type services
			var anotherTypeSetProvider = new AnotherTypeSetProvider();
			var anotherTypeStructureProvider = new ConfigFileAnotherTypeStructureProvider(this.sampleFullSectionName);
			var anotherTypeStructuredDataProvider = new AnotherTypeStructuredDataProvider(anotherTypeSetProvider, anotherTypeStructureProvider);
			this.Bundle.AddService(typeof(IAnotherTypeSetProvider), anotherTypeSetProvider);
			this.Bundle.AddService(typeof(IAnotherTypeStructureProvider), anotherTypeStructureProvider);
			this.Bundle.AddService(typeof(IAnotherTypeStructuredDataProvider), anotherTypeStructuredDataProvider);

			// yet another type services
			var yetAnotherTypeSetProvider = new YetAnotherTypeSetProvider();
			var yetAnotherTypeStructureProvider = new ConfigFileYetAnotherTypeStructureProvider(this.sampleFullSectionName);
			var yetAnotherTypeStructuredDataProvider = new YetAnotherTypeStructuredDataProvider(yetAnotherTypeSetProvider, yetAnotherTypeStructureProvider);
			this.Bundle.AddService(typeof(IYetAnotherTypeSetProvider), yetAnotherTypeSetProvider);
			this.Bundle.AddService(typeof(IYetAnotherTypeStructureProvider), yetAnotherTypeStructureProvider);
			this.Bundle.AddService(typeof(IYetAnotherTypeStructuredDataProvider), yetAnotherTypeStructuredDataProvider);

			// meeting services
			var attendeeProvider = new AttendeeProvider(delegateProvider);
			var meetingProvider = new MeetingProvider(delegateProvider, attendeeProvider);
			this.Bundle.AddService(typeof(IAttendeeProvider), attendeeProvider);
			this.Bundle.AddService(typeof(IMeetingProvider), meetingProvider);

			// context services
			var contextProvider = new SampleContextProvider(this.contextInitData, userDataProvider, meetingProvider);
			this.Bundle.AddServiceResolver(typeof(ISampleContextProvider), new ContextProviderResolver(contextProvider));
		}
	}
}
