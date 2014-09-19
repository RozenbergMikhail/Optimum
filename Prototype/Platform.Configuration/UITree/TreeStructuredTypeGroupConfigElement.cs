//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Configuration;
using Platform.UITree;

namespace Platform.Configuration.UITree
{
	/// <summary>
	/// Contains tree-structured type's group configuration data
	/// </summary>
	public sealed class TreeStructuredTypeGroupConfigElement : TreeStructuredTypeBaseConfigElement
	{
		/// <summary>
		/// Defines name of the "Key" configuration property
		/// </summary>
		public const string KeyPropertyName = "Key";

		/// <summary>
		/// Gets element key
		/// </summary>
		[ConfigurationProperty(KeyPropertyName, IsRequired = true)]
		public string Key
		{
			get
			{
				return (string)base[KeyPropertyName];
			}
		}

		/// <summary>
		/// Gets element key
		/// </summary>
		/// <returns>element key</returns>
		public override string GetElementKey()
		{
			return this.Key;
		}

		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		public override UITreeNodeType GetNodeType()
		{
			return UITreeNodeType.Group;
		}

		/// <summary>
		/// Gets tree node
		/// </summary>
		/// <returns>tree node</returns>
		public override UITreeNode GetTreeNode()
		{
			return new GroupTreeNode();
		}
	}
}
