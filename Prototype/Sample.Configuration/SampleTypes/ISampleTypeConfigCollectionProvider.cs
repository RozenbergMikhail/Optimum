//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Sample.Configuration.SampleTypes
{
	/// <summary>
	/// Declares sample type config collection provider
	/// </summary>
	public interface ISampleTypeConfigCollectionProvider
	{
		/// <summary>
		/// Gets sample type config collection
		/// </summary>
		/// <returns>sample type config collection</returns>
		SampleTypeConfigCollection GetSampleTypeConfigCollection();
	}
}
