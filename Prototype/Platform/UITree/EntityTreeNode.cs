//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.UITree
{
	/// <summary>
	/// Represents entity tree node
	/// </summary>
	public sealed class EntityTreeNode<T> : UITreeNode, IEntityTreeNode<T>
	{
		/// <summary>
		/// Creates new instance of <see cref="EntityTreeNode{T}"/>
		/// </summary>
		/// <param name="entity">entity</param>
		public EntityTreeNode(T entity)
		{
			this.Entity = entity;
		}

		/// <summary>
		/// Gets entity
		/// </summary>
		public T Entity
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
			return UITreeNodeType.Entity;
		}

		/// <summary>
		/// Returns string representation of the instance
		/// </summary>
		/// <returns>string representation of the instance</returns>
		public override string ToString()
		{
			return this.Entity.ToString();
		}

		/// <summary>
		/// Clones tree node
		/// </summary>
		/// <returns>tree node clone</returns>
		public override UITreeNode CloneTreeNode()
		{
			return new EntityTreeNode<T>(this.Entity);
		}

		#region IEntityTreeNode<T> methods

		/// <summary>
		/// Gets entity
		/// </summary>
		/// <returns>entity</returns>
		public T GetEntity()
		{
			return this.Entity;
		}

		#endregion
	}
}
