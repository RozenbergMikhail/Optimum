//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;
using Platform.Development;
using Platform.ServiceResolvers;
using Sample.Delegates;

namespace Sample.Meetings
{
	/// <summary>
	/// Implements meeting attendee provider
	/// </summary>
	public class AttendeeProvider : IAttendeeProvider
	{
		private readonly Dictionary<int, List<Attendee>> attendees;

		/// <summary>
		/// Creates new instance of <see cref="AttendeeProvider"/>
		/// </summary>
		/// <param name="delegateProviderResolver">delegate provider resolver</param>
		public AttendeeProvider(IServiceResolver<IDelegateProvider> delegateProviderResolver)
		{
			if (delegateProviderResolver == null)
				throw new MemoryPointerIsNullException("delegateProviderResolver");

			var delegateProvider = ((ServiceResolver<IDelegateProvider>) delegateProviderResolver).Service;
			this.attendees = LoadAttendees(delegateProvider);
		}

		/// <summary>
		/// Lists attendees of specified meeting
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <returns>attendee instances</returns>
		public IEnumerable<Attendee> ListMeetingAttendees(Context context, int meetingId)
		{
			return this.attendees[meetingId];
		}

		private static Dictionary<int, List<Attendee>> LoadAttendees(IDelegateProvider delegateProvider)
		{
			var result = new Dictionary<int, List<Attendee>>();
			result.Add(1, new List<Attendee>()
			{
				new Attendee(new AttendeeInitData()
				{
					Id = 1,
					DelegateId = 1,
					State = AttendeeState.Confirmed,
					DelegateProvider = delegateProvider,
				}),
			});
			result.Add(2, new List<Attendee>()
			{
				new Attendee(new AttendeeInitData()
				{
					Id = 2,
					DelegateId = 2,
					State = AttendeeState.Tentative,
					DelegateProvider = delegateProvider,
				}),
			});
			return result;
		}
	}
}
