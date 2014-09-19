//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.System
{
	/// <summary>
	/// Implements local time offset provider
	/// </summary>
	public class LocalTimeOffsetProvider : ILocalTimeOffsetProvider
	{
		/// <summary>
		/// Gets current local time offset
		/// </summary>
		/// <returns>current local time offset</returns>
		public TimeSpan GetCurrentLocalTimeOffset()
		{
			return TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
		}
	}
}
