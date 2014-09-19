//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.System
{
	/// <summary>
	/// Declares host name provider
	/// </summary>
	public interface IHostNameProvider
	{
		/// <summary>
		/// Gets current host name
		/// </summary>
		/// <returns>host name</returns>
		string GetCurrentHostName();
	}
}
