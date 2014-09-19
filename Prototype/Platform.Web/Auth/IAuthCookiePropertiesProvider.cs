//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.Web.Auth
{
	/// <summary>
	/// Declares authentication cookie properties provider
	/// </summary>
	public interface IAuthCookiePropertiesProvider
	{
		/// <summary>
		/// Gets authentication cookie properties
		/// </summary>
		/// <returns>authentication cookie properties</returns>
		AuthCookieProperties GetAuthCookieProperties();
	}
}
