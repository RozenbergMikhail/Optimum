//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using Platform.Contexts;
using Platform.Development;
using Platform.ServiceResolvers;
using Sample.Delegates;

namespace Sample.Meetings
{
	/// <summary>
	/// Implements meeting provider
	/// </summary>
	public class MeetingProvider : IMeetingProvider
	{
		private readonly IServiceResolver<IDelegateProvider> delegateProviderResolver;
		private readonly IServiceResolver<IAttendeeProvider> attendeeProviderResolver;
		
		private readonly Dictionary<int, Meeting> meetings;

		/// <summary>
		/// Creates new instance of <see cref="MeetingProvider"/>
		/// </summary>
		/// <param name="delegateProviderResolver">delegate provider resolver</param>
		/// <param name="attendeeProviderResolver">attendee provider resolver</param>
		public MeetingProvider(IServiceResolver<IDelegateProvider> delegateProviderResolver, IServiceResolver<IAttendeeProvider> attendeeProviderResolver)
		{
			if (delegateProviderResolver == null)
				throw new MemoryPointerIsNullException("delegateProviderResolver");

			if (attendeeProviderResolver == null)
				throw new MemoryPointerIsNullException("attendeeProviderResolver");

			this.delegateProviderResolver = delegateProviderResolver;
			this.attendeeProviderResolver = attendeeProviderResolver;

			this.meetings = LoadMeetings(delegateProviderResolver, attendeeProviderResolver);
		}

		/// <summary>
		/// Lists meetings of specified user
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <returns>meeting instances</returns>
		public IEnumerable<Meeting> ListMeetings(Context context, int userId)
		{
			// TODO: use user id to filter meetings
			return this.meetings.Values;
		}

		/// <summary>
		/// Gets meeting by identifier
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <returns>meeting</returns>
		public Meeting GetMeetingById(Context context, int userId, int meetingId)
		{
			// TODO: user user id to check read access to the meeting
			return this.meetings[meetingId];
		}

		/// <summary>
		/// Updates meeting
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <param name="updateData">meeting update data</param>
		public void UpdateMeeting(Context context, int userId, int meetingId, MeetingUpdateData updateData)
		{
			if (updateData == null)
				throw new MemoryPointerIsNullException("updateData");

			// TODO: user user id to check write access to the meeting

			// TODO: implement this method properly (the following implementation is just a hack)
			this.meetings.Remove(meetingId);

			var newMeetingInitData = new MeetingInitData()
			{
				Id = meetingId,
				Name = updateData.Name,
				StartTime = updateData.StartTime,
				EndTime = updateData.EndTime,
				DelegateProviderResolver = this.delegateProviderResolver,
				AttendeeProviderResolver = this.attendeeProviderResolver,
			};
			
			this.meetings.Add(meetingId, new Meeting(newMeetingInitData));
		}

		private static Dictionary<int, Meeting> LoadMeetings(IServiceResolver<IDelegateProvider> delegateProviderResolver, IServiceResolver<IAttendeeProvider> attendeeProviderResolver)
		{
			var result = new Dictionary<int, Meeting>();
			result.Add(1, new Meeting(new MeetingInitData()
			{
				Id = 1,
				Name = "First meeting",
				StartTime = DateTime.Now.AddDays(1),
				EndTime = DateTime.Now.AddDays(1).AddHours(1),
				OrganizerDelegateId = 1,
				DelegateProviderResolver = delegateProviderResolver,
				AttendeeProviderResolver = attendeeProviderResolver,
			}));
			result.Add(2, new Meeting(new MeetingInitData()
			{
				Id = 2,
				Name = "Second meeting",
				StartTime = DateTime.Now.AddDays(-1),
				EndTime = DateTime.Now.AddDays(-1).AddHours(1),
				OrganizerDelegateId = 2,
				DelegateProviderResolver = delegateProviderResolver,
				AttendeeProviderResolver = attendeeProviderResolver,
			}));
			return result;
		}
	}
}
