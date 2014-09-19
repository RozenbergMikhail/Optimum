//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;

namespace Sample.AnotherTypes
{
	/// <summary>
	/// Declares another sample type set provider
	/// </summary>
	public interface IAnotherTypeSetProvider
	{
		/// <summary>
		/// Gets another sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>another sample type instances</returns>
		IEnumerable<AnotherType> GetAnotherTypeInstances(Context context);

		/// <summary>
		/// Gets another sample type instance by name
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="name">name</param>
		/// <returns>another sample type instance</returns>
		AnotherType GetAnotherTypeInstanceByName(Context context, string name);
	}
}
