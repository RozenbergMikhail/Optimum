//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.System
{
	/// <summary>
	/// Declares UTC time provider
	/// </summary>
	public class UTCTimeProvider : IUTCTimeProvider
	{
		/// <summary>
		/// Gets current UTC time
		/// </summary>
		/// <returns>UTC time</returns>
		public DateTime GetCurrentUTCTime()
		{
			return DateTime.UtcNow;
		}
	}
}
