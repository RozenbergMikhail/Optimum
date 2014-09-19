//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;

namespace Sample.SampleTypes
{
	/// <summary>
	/// Declares sample type set provider
	/// </summary>
	public interface ISampleTypeSetProvider
	{
		/// <summary>
		/// Gets sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>sample type instances</returns>
		IEnumerable<SampleType> GetSampleTypeInstances(Context context);

		/// <summary>
		/// Gets sample type instance by name
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="name">name</param>
		/// <returns>sample type instance</returns>
		SampleType GetSampleTypeInstanceByName(Context context, string name);
	}
}
