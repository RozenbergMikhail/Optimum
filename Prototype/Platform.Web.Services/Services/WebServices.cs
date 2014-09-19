//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.Services;
using Platform.Web.Auth;
using Platform.Web.Configuration.Auth;

namespace Platform.Web.Bundles.Services
{
	/// <summary>
	/// Defines bundle of web services
	/// </summary>
	public class WebServices : ServiceBundleWrapper
	{
		private readonly string platformWebFullSectionName;

		/// <summary>
		/// Creates new instance of <see cref="WebServices"/>
		/// </summary>
		/// <param name="platformWebFullSectionName">platform web full section name</param>
		public WebServices(string platformWebFullSectionName)
		{
			if (platformWebFullSectionName == null)
				throw new MemoryPointerIsNullException("platformWebFullSectionName");

			this.platformWebFullSectionName = platformWebFullSectionName;
			InitializeBundle();
		}

		private void InitializeBundle()
		{
			var authCookiePropertiesProvider = new ConfigFileAuthCookiePropertiesProvider(this.platformWebFullSectionName);
			this.Bundle.AddService(typeof(IAuthCookiePropertiesProvider), authCookiePropertiesProvider);
		}
	}
}
