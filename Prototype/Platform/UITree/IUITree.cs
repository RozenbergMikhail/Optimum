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
	/// Declares interface of UI tree
	/// </summary>
	public interface IUITree
	{
		/// <summary>
		/// Gets tree roots
		/// </summary>
		List<IUITreeNode> GetRoots();

		/// <summary>
		/// Performs depth-traverse of object tree using specified action
		/// </summary>
		/// <param name="traverseAction">traverse action</param>
		void TraverseDepth(Action<IUITreeNode, int> traverseAction);
	}
}
