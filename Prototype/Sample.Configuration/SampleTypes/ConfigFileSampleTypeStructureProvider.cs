//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Contexts;
using Platform.UITree;
using Sample.SampleTypes;

namespace Sample.Configuration.SampleTypes
{
	/// <summary>
	/// Implements sample type structure provider using configuration file as structure source
	/// </summary>
	public class ConfigFileSampleTypeStructureProvider : ISampleTypeStructureProvider
	{
		private readonly SampleTypeConfigCollection sampleTypeConfigCollection;

		/// <summary>
		/// Creates new instance of <see cref="ConfigFileSampleTypeStructureProvider"/>
		/// </summary>
		/// <param name="configSectionFullName">config section full name</param>
		public ConfigFileSampleTypeStructureProvider(string configSectionFullName)
		{
			this.sampleTypeConfigCollection = LoadSampleTypeConfigCollection(configSectionFullName);
		}

		/// <summary>
		/// Gets sample type descriptor tree
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>sample type descriptors tree</returns>
		public IUITree GetSampleTypeDescriptorTree(Context context)
		{
			return this.sampleTypeConfigCollection;
		}

		private static SampleTypeConfigCollection LoadSampleTypeConfigCollection(string configSectionFullName)
		{
			SampleTypeConfigCollection result = null;

			var configurationSection = ConfigurationManager.GetSection(configSectionFullName);
			if (configurationSection != null)
			{
				var sampleTypeConfigCollectionProvider = configurationSection as ISampleTypeConfigCollectionProvider;
				if (sampleTypeConfigCollectionProvider != null)
				{
					result = sampleTypeConfigCollectionProvider.GetSampleTypeConfigCollection();
				}
			}

			return result;
		}
	}
}
