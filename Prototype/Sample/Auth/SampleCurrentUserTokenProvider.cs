//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Auth;
using Platform.Contexts;

namespace Sample.Auth
{
	/// <summary>
	/// Implements current user token provider for sample application
	/// </summary>
	public class SampleCurrentUserTokenProvider : ICurrentUserTokenProvider
	{
		/// <summary>
		/// Gets current user token
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>user token</returns>
		public UserToken GetCurrentUserToken(Context context)
		{
			// TODO: read token data from cookie, possibly using IAuthCookiePropertiesProvider
			return new SampleUserToken(100, DateTime.UtcNow);
		}
	}
}
