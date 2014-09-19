//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Auth;

namespace Sample.Contexts
{
	/// <summary>
	/// Declares context provider for sample application
	/// </summary>
	public interface ISampleContextProvider : IContextProvider
	{
		/// <summary>
		/// Gets meeting context
		/// </summary>
		/// <param name="currentUserToken">current user token</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <returns>meeting context</returns>
		MeetingContext GetMeetingContext(UserToken currentUserToken, int meetingId);
	}
}
