//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Development;
using Platform.Contexts;
using Platform.Entities;
using Platform.ServiceResolvers;
using Sample.Delegates;

namespace Sample.Meetings
{
	/// <summary>
	/// Contains meeting data
	/// </summary>
	public class Meeting : Entity, IEntityWithState<MeetingState>
	{
		private readonly IServiceResolver<IDelegateProvider> delegateProviderResolver;
		private readonly IServiceResolver<IAttendeeProvider> attendeeProviderResolver;

		/// <summary>
		/// Creates new instance of <see cref="Meeting"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public Meeting(MeetingInitData initData)
		{
			if (initData == null)
				throw new MemoryPointerIsNullException("initData");

			initData.ValidatePropertiesNotNull();

			this.Id = initData.Id;
			this.Name = initData.Name;
			this.StartTime = initData.StartTime;
			this.EndTime = initData.EndTime;
			this.OrganizerDelegateId = initData.OrganizerDelegateId;
			this.delegateProviderResolver = initData.DelegateProviderResolver;
			this.attendeeProviderResolver = initData.AttendeeProviderResolver;
		}

		/// <summary>
		/// Gets identifier
		/// </summary>
		public int Id
		{
			get; 
			private set;
		}

		/// <summary>
		/// Gets name
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets start time
		/// </summary>
		public DateTime StartTime
		{
			get;
			private set;
		}


		/// <summary>
		/// Gets end time
		/// </summary>
		public DateTime EndTime
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets organizer delegate identifier
		/// </summary>
		public int OrganizerDelegateId
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets meeting organizer delegate
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>organizer delegate</returns>
		public Delegates.Delegate GetOrganizer(Context context)
		{
			var delegateProvider = this.delegateProviderResolver.GetService(context);
			return delegateProvider.GetDelegate(context, this.OrganizerDelegateId);
		}

		/// <summary>
		/// Lists attendees of current meeting
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>attendees list</returns>
		public List<Attendee> Attendees(Context context)
		{
			var attendeeProvider = this.attendeeProviderResolver.GetService(context);
			return attendeeProvider.ListMeetingAttendees(context, this.Id).ToList();
		}

		/// <summary>
		/// Gets string description of an object with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>string representation</returns>
		public override string GetObjectDescription(Context context)
		{
			return string.Format("Id='{0}'; Name={1}; Start={2}; End={3}", this.Id, this.Name, this.StartTime, this.EndTime);
		}

		#region IEntityWithState methods

		/// <summary>
		/// Gets current entity state
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>current entity state</returns>
		public MeetingState GetState(Context context)
		{
			throw new SourceCodeNotImplementedException();
		}

		#endregion
	}
}
