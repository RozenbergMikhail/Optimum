//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Sample.Meetings
{
	/// <summary>
	/// Contains meeting update data
	/// </summary>
	public class MeetingUpdateData
	{
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
	}
}
