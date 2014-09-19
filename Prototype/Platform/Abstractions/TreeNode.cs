//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;

namespace Platform.Abstractions
{
	/// <summary>
	/// Represents tree node
	/// </summary>
	/// 
	public sealed class TreeNode<T>
	{
		private readonly List<TreeNode<T>> childNodes;

		/// <summary>
		/// Creates new <see cref="TreeNode{T}"/> instance
		/// </summary>
		/// <param name="entity">entity instance stored in the node</param>
		public TreeNode(T entity)
		{
			this.Entity = entity;
			this.childNodes = new List<TreeNode<T>>();
		}

		/// <summary>
		/// Creates new <see cref="TreeNode{T}"/> instance
		/// </summary>
		/// <param name="entity">entity instance stored in the node</param>
		/// <param name="childNodes">child nodes</param>
		public TreeNode(T entity, IEnumerable<TreeNode<T>> childNodes)
		{
			this.Entity = entity;
			this.childNodes = new List<TreeNode<T>>(childNodes);
		}

		/// <summary>
		/// Gets entity stored in the node
		/// </summary>
		public T Entity
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets immediate child node list
		/// </summary>
		public List<TreeNode<T>> ChildNodes
		{
			get
			{
				return this.childNodes;
			}
		}

		/// <summary>
		/// Gets leaf child entity list
		/// </summary>
		/// <returns>leaf child entity list</returns>
		public List<T> GetLeafChildEntities()
		{
			var result = new List<T>();

			foreach (var childNode in this.ChildNodes)
			{
				if (childNode.ChildNodes.Count > 0)
				{
					result.AddRange(childNode.GetLeafChildEntities());
				}
				else
				{
					result.Add(childNode.Entity);
				}
			}

			return result;
		}
	}
}
