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
	/// Declares entity operation tree provider
	/// </summary>
	/// <typeparam name="TOperationEnum">operation enum type</typeparam>
	public interface IEntityOperationTreeProvider<TOperationEnum>
		where TOperationEnum : struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets entity operation tree root
		/// </summary>
		/// <returns>entity operation tree root</returns>
		TreeNode<TOperationEnum> GetEntityOperationTreeRoot();
	}
}
