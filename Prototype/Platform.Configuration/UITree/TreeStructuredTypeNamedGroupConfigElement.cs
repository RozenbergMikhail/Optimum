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
	/// Contains tree-structured type's named group configuration data
	/// </summary>
	public sealed class TreeStructuredTypeNamedGroupConfigElement : TreeStructuredTypeBaseConfigElement, INamedGroupTreeNode
	{
		/// <summary>
		/// Defines name of the "DisplayName" configuration property
		/// </summary>
		public const string DisplayNamePropertyName = "DisplayName";

		/// <summary>
		/// Gets card source name
		/// </summary>
		[ConfigurationProperty(DisplayNamePropertyName, IsRequired = true, IsKey = true)]
		public string DisplayName
		{
			get
			{
				return (string)base[DisplayNamePropertyName];
			}
		}

		/// <summary>
		/// Gets element key
		/// </summary>
		/// <returns>element key</returns>
		public override string GetElementKey()
		{
			return this.DisplayName;
		}

		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		public override UITreeNodeType GetNodeType()
		{
			return UITreeNodeType.NamedGroup;
		}

		/// <summary>
		/// Gets tree node
		/// </summary>
		/// <returns>tree node</returns>
		public override UITreeNode GetTreeNode()
		{
			return new NamedGroupTreeNode(this.DisplayName);
		}

		#region INamedGroupTreeNode members

		/// <summary>
		/// Gets group name
		/// </summary>
		/// <returns>group name</returns>
		public string GetGroupName()
		{
			return this.DisplayName;
		}

		#endregion
	}
}
