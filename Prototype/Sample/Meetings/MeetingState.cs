//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Sample.Meetings
{
	/// <summary>
	/// Enumerates possible meeting states
	/// </summary>
	public enum MeetingState
	{
		/// <summary>
		/// All meeting states
		/// </summary>
		All = 0,

		/// <summary>
		/// Active meeting
		/// </summary>
		Active = 1,
		
		/// <summary>
		/// Cancelled meeting
		/// </summary>
		Cancelled = 3,

		/// <summary>
		/// Past meeting
		/// </summary>
		Past = 4,

		/// <summary>
		/// Rescheduled meeting
		/// </summary>
		Rescheduled = 5,
	}
}
