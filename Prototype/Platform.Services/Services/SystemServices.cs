//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.Services;
using Platform.System;

namespace Platform.Bundles.Services
{
	/// <summary>
	/// Defines bundle of system services
	/// </summary>
	public class SystemServices : ServiceBundleWrapper
	{
		private readonly string platformFullSectionName;

		/// <summary>
		/// Creates new instance of <see cref="SystemServices"/>
		/// </summary>
		/// <param name="platformFullSectionName">platform full section name</param>
		public SystemServices(string platformFullSectionName)
		{
			if (platformFullSectionName == null)
				throw new MemoryPointerIsNullException("platformFullSectionName");

			this.platformFullSectionName = platformFullSectionName;
			InitializeBundle();
		}

		private void InitializeBundle()
		{
			var utcTimeProvider = new UTCTimeProvider();
			var localTimeOffsetProvider = new LocalTimeOffsetProvider();
			var uiCultureProvider = new UICultureProvider();
			var consoleProvider = new ConsoleProvider();
			this.Bundle.AddService(typeof(IUTCTimeProvider), utcTimeProvider);
			this.Bundle.AddService(typeof(ILocalTimeOffsetProvider), localTimeOffsetProvider);
			this.Bundle.AddService(typeof(IUICultureProvider), uiCultureProvider);
			this.Bundle.AddService(typeof(IConsoleProvider), consoleProvider);
		}
	}
}
