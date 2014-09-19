//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.UITree
{
	/// <summary>
	/// Represents group tree node
	/// </summary>
	public sealed class GroupTreeNode : UITreeNode
	{
		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		public override UITreeNodeType GetNodeType()
		{
			return UITreeNodeType.Group;
		}

		/// <summary>
		/// Returns string representation of the instance
		/// </summary>
		/// <returns>string representation of the instance</returns>
		public override string ToString()
		{
			return string.Empty;
		}

		/// <summary>
		/// Clones tree node
		/// </summary>
		/// <returns>tree node clone</returns>
		public override UITreeNode CloneTreeNode()
		{
			return new GroupTreeNode();
		}
	}
}
