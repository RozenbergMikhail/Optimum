//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;

namespace Platform.UITree
{
	/// <summary>
	/// Declares interface of UI tree node
	/// </summary>
	public interface IUITreeNode
	{
		/// <summary>
		/// Gets node type
		/// </summary>
		/// <returns>tree node type</returns>
		UITreeNodeType GetNodeType();

		/// <summary>
		/// Gets child nodes
		/// </summary>
		/// <returns>child nodes</returns>
		List<IUITreeNode> GetChildNodes();

		/// <summary>
		/// Gets tree node corresponding to the current instance
		/// </summary>
		/// <returns>tree node</returns>
		UITreeNode GetTreeNode();

		/// <summary>
		/// Performs depth-traverse of object tree using specified action
		/// </summary>
		/// <param name="traverseAction">traverse action</param>
		/// <param name="depth">tree depth</param>
		void TraverseDepth(Action<IUITreeNode, int> traverseAction, int depth);
	}
}
