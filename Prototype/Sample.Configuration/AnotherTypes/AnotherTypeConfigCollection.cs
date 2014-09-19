//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.Configuration.UITree;

namespace Sample.Configuration.AnotherTypes
{
	/// <summary>
	/// Contains another sample type configuration collection 
	/// </summary>
	[ConfigurationCollection(typeof(TreeStructuredTypeBaseConfigElement))]
	public class AnotherTypeConfigCollection : TreeStructuredTypeConfigCollection
	{
		/// <summary>
		/// Defines name of the "AnotherType" item of the configuration section
		/// </summary>
		public const string AnotherTypeSectionItemName = "AnotherType";

		/// <summary>
		/// Gets entity tag name
		/// </summary>
		/// <returns>entity tag name</returns>
		protected override string GetEntityTagName()
		{
			return AnotherTypeSectionItemName;
		}

		/// <summary>
		/// Gets members config collection
		/// </summary>
		/// <returns>members config collection</returns>
		protected override TreeStructuredTypeConfigCollection GetMembersConfigCollection()
		{
			return new AnotherTypeConfigCollection();
		}
	}
}
