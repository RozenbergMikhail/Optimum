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
	/// Declares sample type structured data provider
	/// </summary>
	public interface ISampleTypeStructuredDataProvider
	{
		/// <summary>
		/// Lists sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>list of sample type instances</returns>
		List<SampleType> ListSampleTypes(Context context);
	}
}
