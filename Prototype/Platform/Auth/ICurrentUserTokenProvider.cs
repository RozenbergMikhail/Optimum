//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Platform.Auth
{
	/// <summary>
	/// Declares current user token provider
	/// </summary>
	public interface ICurrentUserTokenProvider
	{
		/// <summary>
		/// Gets current user token
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>user token</returns>
		UserToken GetCurrentUserToken(Context context);
	}
}
