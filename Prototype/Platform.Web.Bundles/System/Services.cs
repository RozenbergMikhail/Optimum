//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.ServiceResolvers;
using Platform.System;
using Platform.Web.System;

namespace Platform.Web.Bundles.System
{
	/// <summary>
	/// Defines bundle of system web services
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

			var utcTimeProviderResolver = new ServiceResolver<IUTCTimeProvider>(new UTCTimeProvider());
			var localTimeOffsetProviderResolver = new ServiceResolver<ILocalTimeOffsetProvider>(new WebLocalTimeOffsetProvider()); // notice this service differs from non-web system bundle
			var uiCultureProviderResolver = new ServiceResolver<IUICultureProvider>(new UICultureProvider()); // probably this service should be different too
			var consoleProviderResolver = new ServiceResolver<IConsoleProvider>(new ConsoleProvider());
			this.Bundle.AddServiceResolver(utcTimeProviderResolver);
			this.Bundle.AddServiceResolver(localTimeOffsetProviderResolver);
			this.Bundle.AddServiceResolver(uiCultureProviderResolver);
			this.Bundle.AddServiceResolver(consoleProviderResolver);
		}
	}
}
