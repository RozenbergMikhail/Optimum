//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Development;
using Platform.ServiceResolvers;
using Sample.Delegates;

namespace Sample.Meetings
{
	/// <summary>
	/// Contains meeting initialization data
	/// </summary>
	public class MeetingInitData
	{
		/// <summary>
		/// Gets or sets meeting identifier
		/// </summary>
		public int Id
		{
			get; 
			set;
		}

		/// <summary>
		/// Gets or sets name
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets start time
		/// </summary>
		public DateTime StartTime
		{
			get; 
			set;
		}

		/// <summary>
		/// Gets or sets end time
		/// </summary>
		public DateTime EndTime
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets organizer delegate identifier
		/// </summary>
		public int OrganizerDelegateId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets delegate provider resolver
		/// </summary>
		public IServiceResolver<IDelegateProvider> DelegateProviderResolver
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets attendee provider resolver
		/// </summary>
		public IServiceResolver<IAttendeeProvider> AttendeeProviderResolver
		{
			get; 
			set; 
		}

		/// <summary>
		/// Validates initialization data
		/// </summary>
		public virtual void ValidatePropertiesNotNull()
		{
			if (this.DelegateProviderResolver == null)
				throw new MemoryPointerIsNullException("DelegateProviderResolver");

			if (this.AttendeeProviderResolver == null)
				throw new MemoryPointerIsNullException("AttendeeProviderResolver");
		}
	}
}
