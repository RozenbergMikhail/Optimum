//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Sample.Meetings
{
	/// <summary>
	/// Enumerates possible meeting user roles
	/// </summary>
	public enum MeetingUserRole
	{
		/// <summary>
		/// All meeting user roles
		/// </summary>
		All = 0,

		/// <summary>
		/// All related to meeting
		/// </summary>
		RelatedToMeeting = 1,

		/// <summary>
		/// Meeting organizer
		/// </summary>
		Organizer = 2,

		/// <summary>
		/// Meeting attendee
		/// </summary>
		Attendee = 3,

		/// <summary>
		/// Not related to meeting
		/// </summary>
		NotRelatedToMeeting = 4,
	}
}
