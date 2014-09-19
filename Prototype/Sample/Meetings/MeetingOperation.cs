//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Sample.Meetings
{
	/// <summary>
	/// Enumerates possible meeting operations
	/// </summary>
	public enum MeetingOperation
	{
		/// <summary>
		/// All meeting operations
		/// </summary>
		All = 0,

		/// <summary>
		/// Create meeting
		/// </summary>
		Create = 1,

		/// <summary>
		/// Edit meeting
		/// </summary>
		Edit = 2,

		/// <summary>
		/// Cancel meeting
		/// </summary>
		Cancel = 3,

		/// <summary>
		/// Reschedule meeting
		/// </summary>
		Reschedule = 4,

		/// <summary>
		/// Accept meeting
		/// </summary>
		Accept = 5,

		/// <summary>
		/// Reject meeting
		/// </summary>
		Reject = 6,

		/// <summary>
		/// Propose new time for meeting
		/// </summary>
		ProposeNewTime = 7,
	}
}
