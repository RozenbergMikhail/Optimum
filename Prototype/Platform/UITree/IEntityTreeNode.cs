//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.UITree
{
	/// <summary>
	/// Declares interface of entity tree node
	/// </summary>
	/// <typeparam name="TEntity">entity type</typeparam>
	public interface IEntityTreeNode<out TEntity> : IUITreeNode
	{
		/// <summary>
		/// Gets entity
		/// </summary>
		/// <returns>entity</returns>
		TEntity GetEntity();
	}
	
}
