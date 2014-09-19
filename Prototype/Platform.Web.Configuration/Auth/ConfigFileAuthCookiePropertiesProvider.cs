//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Web.Auth;

namespace Platform.Web.Configuration.Auth
{
	/// <summary>
	/// Implements authentication cookie properties provider using data from config file
	/// </summary>
	public class ConfigFileAuthCookiePropertiesProvider : IAuthCookiePropertiesProvider
	{
		private readonly AuthCookieProperties cookieProperties;

		/// <summary>
		/// Creates new instance of <see cref="ConfigFileAuthCookiePropertiesProvider"/>
		/// </summary>
		/// <param name="configSectionFullName">config section full name</param>
		public ConfigFileAuthCookiePropertiesProvider(string configSectionFullName)
		{
			this.cookieProperties = LoadAuthCookieProperties(configSectionFullName);
		}

		/// <summary>
		/// Gets authentication cookie properties
		/// </summary>
		/// <returns>authentication cookie properties</returns>
		public AuthCookieProperties GetAuthCookieProperties()
		{
			return cookieProperties;
		}

		private static AuthCookieProperties LoadAuthCookieProperties(string configSectionFullName)
		{
			AuthCookieProperties result = null;

			var configurationSection = ConfigurationManager.GetSection(configSectionFullName);
			if (configurationSection != null)
			{
				var authCookieConfigElementProvider = configurationSection as IAuthCookieConfigElementProvider;
				if (authCookieConfigElementProvider != null)
				{
					var authCookieConfigElement = authCookieConfigElementProvider.GetAuthCookieConfigElement();
					if (authCookieConfigElement != null && authCookieConfigElement.Initialized)
					{
						result = new AuthCookieProperties(authCookieConfigElement.Name);
					}
				}
			}

			return result;
		}
	}
}
