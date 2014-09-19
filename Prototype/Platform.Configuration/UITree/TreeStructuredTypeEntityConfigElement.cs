//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Configuration;
using Platform.UITree;

namespace Platform.Configuration.UITree
{
	/// <summary>
	/// Contains tree-structured type's entity configuration data
	/// </summary>
	public sealed class TreeStructuredTypeEntityConfigElement : TreeStructuredTypeBaseConfigElement, IEntityTreeNode<string>
	{
		/// <summary>
		/// Defines name of the "Namespace" configuration property
		/// </summary>
		public const string NamespacePropertyName = "Namespace";

		/// <summary>
		/// Defines name of the "Name" configuration property
		/// </summary>
		public const string NamePropertyName = "Name";

		/// <summary>
		/// Gets entity namespace
		/// </summary>
		[ConfigurationProperty(NamespacePropertyName)]
		public string Namespace
		{
			get
			{
				return (string)base[NamespacePropertyName];
			}
		}

		/// <summary>
		/// Gets entity name
		/// </summary>
		[ConfigurationProperty(NamePropertyName, IsRequired = true, IsKey = true)]
		public string Name
		{
			get
			{
				return (string)base[NamePropertyName];
			}
		}

		/// <summary>
		/// Gets element key
		/// </summary>
		/// <returns>element key</returns>
		public override string GetElementKey()
		{
			string result;
			if (!String.IsNullOrEmpty(this.Namespace))
			{
				result = string.Format("{0}.{1}", this.Namespace, this.Name);
			}
			else
			{
				result = this.Name;
			}
			return result;
		}

		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		public override UITreeNodeType GetNodeType()
		{
			return UITreeNodeType.Entity;
		}

		/// <summary>
		/// Gets tree node
		/// </summary>
		/// <returns>tree node</returns>
		public override UITreeNode GetTreeNode()
		{
			return new EntityTreeNode<string>(this.GetEntity());
		}

		#region IEntityTreeNode<string> members

		/// <summary>
		/// Gets entity
		/// </summary>
		/// <returns>entity</returns>
		public string GetEntity()
		{
			return this.GetElementKey();
		}


		#endregion
	}
}
