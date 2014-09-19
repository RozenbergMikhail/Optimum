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
	public interface IUTCTimeProvider
	{
		/// <summary>
		/// Gets current UTC time
		/// </summary>
		/// <returns>UTC time</returns>
		DateTime GetCurrentUTCTime();
	}
}
