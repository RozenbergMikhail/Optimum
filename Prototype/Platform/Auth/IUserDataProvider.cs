//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Platform.Auth
{
	/// <summary>
	/// Declares user data provider
	/// </summary>
	public interface IUserDataProvider
	{
		/// <summary>
		/// Gets user data by user token
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userToken">user token</param>
		/// <returns>user data</returns>
		UserData GetUserData(Context context, UserToken userToken);
	}
}
