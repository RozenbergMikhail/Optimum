//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Net;

namespace Platform.System
{
	/// <summary>
	/// Declares IP address provider
	/// </summary>
	public interface IIPAddressProvider
	{
		/// <summary>
		/// Gets IP Address of the current host
		/// </summary>
		/// <returns>IP address</returns>
		IPAddress GetCurrentHostIpAddress();
	}
}
