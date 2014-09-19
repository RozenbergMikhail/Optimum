//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;

namespace Sample.Meetings
{
	/// <summary>
	/// Declares meeting attendee provider
	/// </summary>
	public interface IAttendeeProvider
	{
		/// <summary>
		/// Lists attendees of specified meeting
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <returns>attendee instances</returns>
		IEnumerable<Attendee> ListMeetingAttendees(Context context, int meetingId);
	}
}
