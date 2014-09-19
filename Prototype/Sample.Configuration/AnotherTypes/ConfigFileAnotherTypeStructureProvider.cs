//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Contexts;
using Platform.UITree;
using Sample.AnotherTypes;

namespace Sample.Configuration.AnotherTypes
{
	/// <summary>
	/// Implements another sample type structure provider using configuration file as structure source
	/// </summary>
	public class ConfigFileAnotherTypeStructureProvider : IAnotherTypeStructureProvider
	{
		private readonly AnotherTypeConfigCollection anotherTypeConfigCollection;

		/// <summary>
		/// Creates new instance of <see cref="ConfigFileAnotherTypeStructureProvider"/>
		/// </summary>
		/// <param name="configSectionFullName">config section full name</param>
		public ConfigFileAnotherTypeStructureProvider(string configSectionFullName)
		{
			this.anotherTypeConfigCollection = LoadAnotherTypeConfigCollection(configSectionFullName);
		}

		/// <summary>
		/// Gets another sample type descriptor tree
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>another sample type descriptors tree</returns>
		public IUITree GetAnotherTypeDescriptorTree(Context context)
		{
			return this.anotherTypeConfigCollection;
		}

		private static AnotherTypeConfigCollection LoadAnotherTypeConfigCollection(string configSectionFullName)
		{
			AnotherTypeConfigCollection result = null;

			var configurationSection = ConfigurationManager.GetSection(configSectionFullName);
			if (configurationSection != null)
			{
				var anotherTypeConfigCollectionProvider = configurationSection as IAnotherTypeConfigCollectionProvider;
				if (anotherTypeConfigCollectionProvider != null)
				{
					result = anotherTypeConfigCollectionProvider.GetAnotherTypeConfigCollection();
				}
			}

			return result;
		}
	}
}
