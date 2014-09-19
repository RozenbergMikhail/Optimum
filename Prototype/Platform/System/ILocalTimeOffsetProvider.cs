//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.System
{
	/// <summary>
	/// Declares local time offset provider
	/// </summary>
	public interface ILocalTimeOffsetProvider
	{
		/// <summary>
		/// Gets current local time offset
		/// </summary>
		/// <returns>current local time offset</returns>
		TimeSpan GetCurrentLocalTimeOffset();
	}
}
