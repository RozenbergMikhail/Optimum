//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Configuration.UITree;

namespace Sample.Configuration.SampleTypes
{
	/// <summary>
	/// Contains sample type configuration collection
	/// </summary>
	[ConfigurationCollection(typeof(TreeStructuredTypeEntityConfigElement))]
	public sealed class SampleTypeConfigCollection : TreeStructuredTypeConfigCollection
	{
		/// <summary>
		/// Defines name of the "SampleType" item of the configuration section
		/// </summary>
		public const string SampleTypeSectionItemName = "SampleType";

		/// <summary>
		/// Gets entity tag name
		/// </summary>
		/// <returns>entity tag name</returns>
		protected override string GetEntityTagName()
		{
			return SampleTypeSectionItemName;
		}

		/// <summary>
		/// Gets members config collection
		/// </summary>
		/// <returns>members config collection</returns>
		protected override TreeStructuredTypeConfigCollection GetMembersConfigCollection()
		{
			return new SampleTypeConfigCollection();
		}
	}
}
