//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Contexts;
using Platform.UITree;
using Platform.Configuration.UITree;
using Sample.YetAnotherTypes;

namespace Sample.Configuration.YetAnotherTypes
{
	/// <summary>
	/// Implements yet another sample type structure provider using configuration file as structure source
	/// </summary>
	public class ConfigFileYetAnotherTypeStructureProvider : IYetAnotherTypeStructureProvider
	{
		private readonly TreeStructuredTypeConfigCollection yetAnotherTypeConfigCollection;

		/// <summary>
		/// Creates new instance of <see cref="ConfigFileYetAnotherTypeStructureProvider"/>
		/// </summary>
		/// <param name="configSectionFullName">config section full name</param>
		public ConfigFileYetAnotherTypeStructureProvider(string configSectionFullName)
		{
			this.yetAnotherTypeConfigCollection = LoadYetAnotherTypeConfigCollection(configSectionFullName);
		}

		/// <summary>
		/// Gets yet another sample type descriptor tree
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>yet another sample type descriptors tree</returns>
		public IUITree GetYetAnotherTypeDescriptorTree(Context context)
		{
			return this.yetAnotherTypeConfigCollection;
		}

		private static TreeStructuredTypeConfigCollection LoadYetAnotherTypeConfigCollection(string configSectionFullName)
		{
			TreeStructuredTypeConfigCollection result = null;

			var configurationSection = ConfigurationManager.GetSection(configSectionFullName);
			if (configurationSection != null)
			{
				var yetAnotherTypeConfigCollectionProvider = configurationSection as IYetAnotherTypeConfigCollectionProvider;
				if (yetAnotherTypeConfigCollectionProvider != null)
				{
					result = yetAnotherTypeConfigCollectionProvider.GetYetAnotherTypeConfigCollection();
				}
			}

			return result;
		}
	}
}
