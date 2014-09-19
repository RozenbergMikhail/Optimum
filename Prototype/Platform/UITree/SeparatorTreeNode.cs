//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.UITree
{
	/// <summary>
	/// Represents separator tree node
	/// </summary>
	public sealed class SeparatorTreeNode : UITreeNode
	{
		/// <summary>
		/// Gets tree node type
		/// </summary>
		/// <returns>tree node type</returns>
		public override UITreeNodeType GetNodeType()
		{
			return UITreeNodeType.Separator;
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
			return new SeparatorTreeNode();
		}
	}
}
