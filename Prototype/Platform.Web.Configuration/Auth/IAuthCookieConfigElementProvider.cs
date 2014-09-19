//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.Web.Configuration.Auth
{
	/// <summary>
	/// Declares auth cookie config element provider
	/// </summary>
	public interface IAuthCookieConfigElementProvider
	{
		/// <summary>
		/// Gets auth cookie config element
		/// </summary>
		/// <returns>auth cookie config element</returns>
		AuthCookieConfigElement GetAuthCookieConfigElement();
	}
}
