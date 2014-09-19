//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Abstractions;

namespace Platform.Entities
{
	/// <summary>
	/// Declares entity user role tree provider
	/// </summary>
	/// <typeparam name="TEntityUserRoleEnum">entity user role enum type</typeparam>
	public interface IEntityUserRoleTreeProvider<TEntityUserRoleEnum>
		where TEntityUserRoleEnum : struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets entity user role tree root
		/// </summary>
		/// <returns>entity user role tree root</returns>
		TreeNode<TEntityUserRoleEnum> GetEntityUserRoleTreeRoot();
	}
}
