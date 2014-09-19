//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Platform.Auth
{
	/// <summary>
	/// Declares user token provider
	/// </summary>
	public interface IUserTokenProvider
	{
		/// <summary>
		/// Gets user token
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userTokenRequest">user token request</param>
		/// <returns>user token</returns>
		UserToken GetUserToken(Context context, UserTokenRequest userTokenRequest);
	}
}
