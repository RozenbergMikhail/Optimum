//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;

namespace Platform.Contexts
{
	/// <summary>
	/// Declares context provider
	/// </summary>
	public interface IContextProvider
	{
		/// <summary>
		/// Gets current context
		/// </summary>
		/// <returns>current context</returns>
		Context GetCurrentContext();

		/// <summary>
		/// Gets current user context
		/// </summary>
		/// <param name="currentUserToken">current user token</param>
		/// <returns>current user context</returns>
		UserContext GetCurrentUserContext(UserToken currentUserToken);
	}
}
