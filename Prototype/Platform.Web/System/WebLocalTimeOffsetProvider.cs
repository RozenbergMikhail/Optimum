//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.System;
using Platform.Development;

namespace Platform.Web.System
{
	/// <summary>
	/// Implements local time offset provider for web
	/// </summary>
	public class WebLocalTimeOffsetProvider : ILocalTimeOffsetProvider
	{
		/// <summary>
		/// Gets current local time offset
		/// </summary>
		/// <returns>local time offset</returns>
		public TimeSpan GetCurrentLocalTimeOffset()
		{
			// TODO: read data from timezone cookie and maybe other storage to decide what time offset to take
			throw new SourceCodeNotImplementedException();
		}
	}
}
