//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Web.Configuration.Auth;

namespace Platform.Web.Configuration.Sections
{
	/// <summary>
	/// Declares root configuration section for infrastructure with web specificity
	/// </summary>
	public class PlatformWebConfigSection : ConfigurationSection, IAuthCookieConfigElementProvider
	{
		#region AuthCookie element

		/// <summary>
		/// Defines name of the "AuthCookie" configuration element
		/// </summary>
		public const string AuthCookieElementName = "AuthCookie";

		/// <summary>
		/// Gets auth cookie configuration settings
		/// </summary>
		[ConfigurationProperty(AuthCookieElementName, IsRequired = false)]
		public AuthCookieConfigElement AuthCookie
		{
			get
			{
				return (AuthCookieConfigElement)base[AuthCookieElementName];
			}
		}

		/// <summary>
		/// Gets auth cookie config element
		/// </summary>
		/// <returns>auth cookie config element</returns>
		public AuthCookieConfigElement GetAuthCookieConfigElement()
		{
			return this.AuthCookie;
		}

		#endregion
	}
}
