//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Sample.Delegates;

namespace Sample.Meetings
{
	/// <summary>
	/// Contains attendee initialization data
	/// </summary>
	public class AttendeeInitData
	{
		/// <summary>
		/// Gets or sets attendee identifier
		/// </summary>
		public int Id
		{
			get; 
			set;
		}

		/// <summary>
		/// Gets or sets delegate identifier
		/// </summary>
		public int DelegateId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets attendee state
		/// </summary>
		public AttendeeState State
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets delegate provider
		/// </summary>
		public IDelegateProvider DelegateProvider
		{
			get;
			set;
		}
	}
}
