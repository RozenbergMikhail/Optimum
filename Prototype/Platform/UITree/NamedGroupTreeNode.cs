//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.UITree
{
	/// <summary>
	/// Represents named group tree node
	/// </summary>
	public sealed class NamedGroupTreeNode : UITreeNode, INamedGroupTreeNode
	{
		/// <summary>
		/// Creates new instance of <see cref="NamedGroupTreeNode"/>
		/// </summary>
		/// <param name="displayName">named group display name</param>
		public NamedGroupTreeNode(string displayName)
		{
			this.DisplayName = displayName;
		}

		/// <summary>
		/// Gets display name
		/// </summary>
		public string DisplayName
		{
			get;
			private set;
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
		/// Returns string representation of the instance
		/// </summary>
		/// <returns>string representation of the instance</returns>
		public override string ToString()
		{
			return this.DisplayName;
		}

		/// <summary>
		/// Clones tree node
		/// </summary>
		/// <returns>tree node clone</returns>
		public override UITreeNode CloneTreeNode()
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
