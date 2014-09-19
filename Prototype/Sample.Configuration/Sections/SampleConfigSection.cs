//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Configuration.UITree;
using Sample.Configuration.AnotherTypes;
using Sample.Configuration.SampleTypes;
using Sample.Configuration.YetAnotherTypes;

namespace Sample.Configuration.Sections
{
	/// <summary>
	/// Declares sample root configuration section
	/// </summary>
	public class SampleConfigSection : ConfigurationSection, ISampleTypeConfigCollectionProvider, IAnotherTypeConfigCollectionProvider, IYetAnotherTypeConfigCollectionProvider
	{
		#region SampleTypes section

		/// <summary>
		/// Defines name of the "SampleTypes" configuration section
		/// </summary>
		public const string SampleTypesSectionName = "SampleTypes";

		/// <summary>
		/// Gets sample types configuration settings
		/// </summary>
		[ConfigurationProperty(SampleTypesSectionName)]
		public SampleTypeConfigCollection SampleTypes
		{
			get
			{
				return (SampleTypeConfigCollection)base[SampleTypesSectionName];
			}
		}

		/// <summary>
		/// Gets sample type config collection
		/// </summary>
		/// <returns>sample type config collection</returns>
		public SampleTypeConfigCollection GetSampleTypeConfigCollection()
		{
			return this.SampleTypes;
		}

		#endregion

		#region AnotherTypes section

		/// <summary>
		/// Defines name of the "AnotherTypes" configuration section
		/// </summary>
		public const string AnotherTypesSectionName = "AnotherTypes";

		/// <summary>
		/// Gets another sample types configuration settings
		/// </summary>
		[ConfigurationProperty(AnotherTypesSectionName)]
		public AnotherTypeConfigCollection AnotherTypes
		{
			get
			{
				return (AnotherTypeConfigCollection)base[AnotherTypesSectionName];
			}
		}

		/// <summary>
		/// Gets another type config collection
		/// </summary>
		/// <returns>another type config collection</returns>
		public AnotherTypeConfigCollection GetAnotherTypeConfigCollection()
		{
			return this.AnotherTypes;
		}

		#endregion

		#region YetAnotherTypes section

		/// <summary>
		/// Defines name of the "YetAnotherTypes" configuration section
		/// </summary>
		public const string YetAnotherTypesSectionName = "YetAnotherTypes";

		/// <summary>
		/// Gets semaphors configuration settings
		/// </summary>
		[ConfigurationProperty(YetAnotherTypesSectionName)]
		public TreeStructuredTypeConfigCollection YetAnotherTypes
		{
			get
			{
				return (TreeStructuredTypeConfigCollection)base[YetAnotherTypesSectionName];
			}
		}

		/// <summary>
		/// Gets yet another type config collection
		/// </summary>
		/// <returns>yet another type config collection</returns>
		public TreeStructuredTypeConfigCollection GetYetAnotherTypeConfigCollection()
		{
			return this.YetAnotherTypes;
		}
		
		#endregion
	}
}
