//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Development;
using Platform.Auth;
using Platform.ServiceResolvers;
using Sample.Meetings;

namespace Sample.Contexts
{
	/// <summary>
	/// Implements context provider for sample application
	/// </summary>
	public class SampleContextProvider : ContextProvider, ISampleContextProvider
	{
		protected readonly IServiceResolver<IMeetingProvider> meetingProviderResolver;

		/// <summary>
		/// Creates new instance of <see cref="SampleContextProvider"/>
		/// </summary>
		/// <param name="contextInitData">context initialization data</param>
		/// <param name="userDataProviderResolver">user data provider resolver</param>
		/// <param name="meetingProviderResolver">meeting provider resolver</param>
		public SampleContextProvider(
			ContextInitData contextInitData, 
			IServiceResolver<IUserDataProvider> userDataProviderResolver,
			IServiceResolver<IMeetingProvider> meetingProviderResolver)
			: base(contextInitData, userDataProviderResolver)
		{
			if (meetingProviderResolver == null)
				throw new MemoryPointerIsNullException("meetingProviderResolver");

			this.meetingProviderResolver = meetingProviderResolver;
		}

		/// <summary>
		/// Gets meeting context
		/// </summary>
		/// <param name="currentUserToken">current user token</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <returns>meeting context</returns>
		public MeetingContext GetMeetingContext(UserToken currentUserToken, int meetingId)
		{
			var meetingContextInitData = new MeetingContextInitData(this.contextInitData)
			{
				CurrentUserToken = currentUserToken,
				UserDataProviderResolver = this.userDataProviderResolver,
				CurrentMeetingId = meetingId,
				MeetingProviderResolver = this.meetingProviderResolver,
			};

			return new MeetingContext(meetingContextInitData);
		}
	}
}
