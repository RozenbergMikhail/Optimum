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
	/// Declares meeting provider
	/// </summary>
	public interface IMeetingProvider
	{
		/// <summary>
		/// Lists meetings of specified user
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <returns>meeting instances</returns>
		IEnumerable<Meeting> ListMeetings(Context context, int userId);

		/// <summary>
		/// Gets meeting by identifier
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <returns>meeting</returns>
		Meeting GetMeetingById(Context context, int userId, int meetingId);

		/// <summary>
		/// Updates meeting
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <param name="updateData">meeting update data</param>
		void UpdateMeeting(Context context, int userId, int meetingId, MeetingUpdateData updateData);
	}
}
