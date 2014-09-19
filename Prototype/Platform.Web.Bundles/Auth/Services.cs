//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.ServiceResolvers;
using Platform.Web.Auth;
using Platform.Web.Configuration.Auth;

namespace Platform.Web.Bundles.Auth
{
	/// <summary>
	/// Defines bundle of auth web services
	/// </summary>
	public class Services : ServiceBundleWrapper
	{
		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		/// <param name="platformWebFullSectionName">platform web full section name</param>
		public Services(string platformWebFullSectionName)
		{
			if (platformWebFullSectionName == null)
				throw new MemoryPointerIsNullException("platformWebFullSectionName");

			var authCookiePropertiesProviderResolver = new ServiceResolver<IAuthCookiePropertiesProvider>(new ConfigFileAuthCookiePropertiesProvider(platformWebFullSectionName));
			this.Bundle.AddServiceResolver(authCookiePropertiesProviderResolver);
		}
	}
}
