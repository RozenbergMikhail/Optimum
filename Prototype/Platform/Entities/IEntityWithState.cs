//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Contexts;

namespace Platform.Entities
{
	/// <summary>
	/// Declares interface of an entity with formalized state
	/// </summary>
	/// <typeparam name="TStateEnum">state enum type</typeparam>
	public interface IEntityWithState<TStateEnum> 
		where TStateEnum: struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets current entity state
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>current entity state</returns>
		TStateEnum GetState(Context context);
	}
}
