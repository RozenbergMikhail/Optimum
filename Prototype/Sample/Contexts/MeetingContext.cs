//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.ServiceResolvers;
using Sample.Auth;
using Sample.Meetings;

namespace Sample.Contexts
{
	/// <summary>
	/// Contains meeting context data used in an operation with meeting
	/// </summary>
	public class MeetingContext : UserContext
	{
		private readonly IServiceResolver<IMeetingProvider> meetingProviderResolver;
		private volatile Meeting currentMeeting;

		/// <summary>
		/// Creates new instance of <see cref="UserContext"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public MeetingContext(MeetingContextInitData initData)
			: base(initData)
		{
			this.CurrentMeetingId = initData.CurrentMeetingId;
			this.meetingProviderResolver = initData.MeetingProviderResolver;
		}

		/// <summary>
		/// Gets current meeting identifier
		/// </summary>
		public int CurrentMeetingId
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets current meeting associated with the context
		/// </summary>
		/// <returns>meeting</returns>
		public Meeting GetCurrentMeeting()
		{
			var result = this.currentMeeting;
			if (result == null)
			{
				lock (this.syncRoot)
				{
					if (this.currentMeeting == null)
					{
						this.currentMeeting = this.LoadMeeting(this.GetCurrentUserToken<SampleUserToken>().UserId, this.CurrentMeetingId);
					}
					result = this.currentMeeting;
				}
			}
			return result;
		}

		/// <summary>
		/// Updates current meeting associated with the context
		/// </summary>
		/// <param name="updateData">meeting update data</param>
		public void UpdateCurrentMeeting(MeetingUpdateData updateData)
		{
			this.meetingProviderResolver.GetService(this).UpdateMeeting(this, this.GetCurrentUserToken<SampleUserToken>().UserId, this.CurrentMeetingId, updateData);
			ClearCachedMeeting();
		}

		/// <summary>
		/// Loads meeting instance
		/// </summary>
		/// <param name="userId">user identifier</param>
		/// <param name="meetingId">meeting identifier</param>
		/// <returns>meeting</returns>
		protected virtual Meeting LoadMeeting(int userId, int meetingId)
		{
			// TODO: can implement caching here
			return this.meetingProviderResolver.GetService(this).GetMeetingById(this, userId, meetingId);
		}

		private void ClearCachedMeeting()
		{
			lock (this.syncRoot)
			{
				this.currentMeeting = null;
			}
		}
	}
}
