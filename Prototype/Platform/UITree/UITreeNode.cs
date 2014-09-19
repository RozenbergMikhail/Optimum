//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Platform.UITree
{
	/// <summary>
	/// Defines base class of UI tree node
	/// </summary>
	public abstract class UITreeNode : IUITreeNode
	{
		private readonly List<UITreeNode> childNodes;

		/// <summary>
		/// Creates new instance of <see cref="UITreeNode"/>
		/// </summary>
		protected UITreeNode()
		{
			this.childNodes = new List<UITreeNode>();
		}

		/// <summary>
		/// Gets child nodes
		/// </summary>
		public List<UITreeNode> ChildNodes
		{
			get
			{
				return this.childNodes;
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
			return this.ChildNodes.Cast<IUITreeNode>().ToList();
		}

		/// <summary>
		/// Gets tree node corresponding to the current instance
		/// </summary>
		/// <returns>tree node</returns>
		UITreeNode IUITreeNode.GetTreeNode()
		{
			return this.CloneTreeNode();
		}

		/// <summary>
		/// Performs depth-traverse of object tree using specified action
		/// </summary>
		/// <param name="traverseAction">traverse action</param>
		/// <param name="depth">tree depth</param>
		void IUITreeNode.TraverseDepth(Action<IUITreeNode, int> traverseAction, int depth)
		{
			traverseAction(this, depth);
			foreach (var node in this.ChildNodes.Cast<IUITreeNode>())
			{
				node.TraverseDepth(traverseAction, depth + 1);
			}
		}

		#endregion

		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		public abstract UITreeNodeType GetNodeType();

		/// <summary>
		/// Clones tree node
		/// </summary>
		/// <returns>tree node clone</returns>
		public abstract UITreeNode CloneTreeNode();
	}
}
