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
	/// Declares entity state tree provider
	/// </summary>
	/// <typeparam name="TStateEnum">state enum type</typeparam>
	public interface IEntityStateTreeProvider<TStateEnum>
		where TStateEnum: struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets entity state tree root
		/// </summary>
		/// <returns>entity state tree root</returns>
		TreeNode<TStateEnum> GetEntityStateTreeRoot();
	}
}
