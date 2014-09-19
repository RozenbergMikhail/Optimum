//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using Platform.Contexts;

namespace Platform.Entities
{
	/// <summary>
	/// Declares interface of an entity with formalized operations
	/// </summary>
	/// <typeparam name="TOperationEnum">operation enum type</typeparam>
	public interface IEntityWithOperations<TOperationEnum> 
		where TOperationEnum: struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets operations available for the specified user in the current entity state
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <returns>available operations</returns>
		IEnumerable<TOperationEnum> GetAvailableOperations(UserContext userContext);

		/// <summary>
		/// Gets a value indicating whether the specified operation is available for specified user in the current entity state
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <param name="operation">operation</param>
		/// <returns>true, if the operation is available; otherwise, false</returns>
		bool CheckOperationAvailable(UserContext userContext, TOperationEnum operation);
	}
}
