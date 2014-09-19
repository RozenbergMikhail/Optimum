//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.ServiceResolvers;
using Sample.Delegates;
using Sample.Meetings;

namespace Sample.Bundles.Meetings
{
	/// <summary>
	/// Defines bundle of meeting services
	/// </summary>
	public class Services : ServiceBundleWrapper
	{
		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		/// <param name="delegateProviderResolver">delegate provider resolver</param>
		public Services(IServiceResolver<IDelegateProvider> delegateProviderResolver)
		{
			if (delegateProviderResolver == null)
				throw new MemoryPointerIsNullException("delegateProviderResolver");

			var attendeeProviderResolver = new ServiceResolver<IAttendeeProvider>(new AttendeeProvider(delegateProviderResolver));
			var meetingProviderResolver = new ServiceResolver<IMeetingProvider>(new MeetingProvider(delegateProviderResolver, attendeeProviderResolver));
			this.Bundle.AddServiceResolver(attendeeProviderResolver);
			this.Bundle.AddServiceResolver(meetingProviderResolver);
		}
	}
}
