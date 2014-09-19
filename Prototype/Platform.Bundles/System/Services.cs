//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.ServiceResolvers;
using Platform.System;

namespace Platform.Bundles.System
{
	/// <summary>
	/// Defines bundle of system services
	/// </summary>
	public class Services : ServiceBundleWrapper
	{
		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		/// <param name="platformFullSectionName">platform full section name</param>
		public Services(string platformFullSectionName)
		{
			if (platformFullSectionName == null)
				throw new MemoryPointerIsNullException("platformFullSectionName");

			var utcTimeProviderResolver = new ServiceResolver<IUTCTimeProvider>(new UTCTimeProvider());
			var localTimeOffsetProviderResolver = new ServiceResolver<ILocalTimeOffsetProvider>(new LocalTimeOffsetProvider());
			var uiCultureProviderResolver = new ServiceResolver<IUICultureProvider>(new UICultureProvider());
			var consoleProviderResolver = new ServiceResolver<IConsoleProvider>(new ConsoleProvider());
			this.Bundle.AddServiceResolver(utcTimeProviderResolver);
			this.Bundle.AddServiceResolver(localTimeOffsetProviderResolver);
			this.Bundle.AddServiceResolver(uiCultureProviderResolver);
			this.Bundle.AddServiceResolver(consoleProviderResolver);
		}
	}
}
