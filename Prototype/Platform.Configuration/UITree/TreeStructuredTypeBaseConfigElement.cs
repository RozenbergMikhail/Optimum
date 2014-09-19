//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Linq;
using System.Xml;
using System.Configuration;
using System.Collections.Generic;
using Platform.UITree;

namespace Platform.Configuration.UITree
{
	/// <summary>
	/// Contains tree structured type base configuration data
	/// </summary>
	public abstract class TreeStructuredTypeBaseConfigElement : ConfigurationElement, IUITreeNode
	{
		/// <summary>
		/// Defines name of the "Members" configuration section
		/// </summary>
		public const string MembersSectionName = "Members";

		/// <summary>
		/// Gets or sets members
		/// </summary>
		[ConfigurationProperty(MembersSectionName)]
		public TreeStructuredTypeConfigCollection Members
		{
			get
			{
				return (TreeStructuredTypeConfigCollection)base[MembersSectionName];
			}
			set
			{
				base[MembersSectionName] = value;
			}
		}

		#region ITreeNode members

		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		UITreeNodeType IUITreeNode.GetNodeType()
		{
			return this.GetNodeType();
		}

		/// <summary>
		/// Gets child nodes
		/// </summary>
		/// <returns>child nodes</returns>
		List<IUITreeNode> IUITreeNode.GetChildNodes()
		{
			return this.Members.Cast<IUITreeNode>().ToList();
		}

		/// <summary>
		/// Gets tree node corresponding to the current instance
		/// </summary>
		/// <returns>tree node</returns>
		UITreeNode IUITreeNode.GetTreeNode()
		{
			return this.GetTreeNode();
		}

		/// <summary>
		/// Performs depth-traverse of object tree using specified action
		/// </summary>
		/// <param name="traverseAction">traverse action</param>
		/// <param name="depth">tree depth</param>
		void IUITreeNode.TraverseDepth(Action<IUITreeNode, int> traverseAction, int depth)
		{
			traverseAction(this, depth);
			foreach (var node in this.Members.Cast<IUITreeNode>())
			{
				node.TraverseDepth(traverseAction, depth + 1);
			}
		}

		#endregion

		/// <summary>
		/// Gets element key
		/// </summary>
		/// <returns>element key</returns>
		public abstract string GetElementKey();

		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		public abstract UITreeNodeType GetNodeType();

		/// <summary>
		/// Gets tree node
		/// </summary>
		/// <returns>tree node</returns>
		public abstract UITreeNode GetTreeNode();

		internal void Deserialize(XmlReader reader)
		{
			base.DeserializeElement(reader, false);
		}
	}
}
