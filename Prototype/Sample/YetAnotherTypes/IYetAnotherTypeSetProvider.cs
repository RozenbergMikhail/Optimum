//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;

namespace Sample.YetAnotherTypes
{
	/// <summary>
	/// Declares yet another sample type set provider
	/// </summary>
	public interface IYetAnotherTypeSetProvider
	{
		/// <summary>
		/// Gets yet another sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>yet another sample type instances</returns>
		IEnumerable<YetAnotherType> GetYetAnotherTypeInstances(Context context);

		/// <summary>
		/// Gets yet another sample type instance by name
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="name">name</param>
		/// <returns>yet another sample type instance</returns>
		YetAnotherType GetYetAnotherTypeInstanceByName(Context context, string name);
	}
}
