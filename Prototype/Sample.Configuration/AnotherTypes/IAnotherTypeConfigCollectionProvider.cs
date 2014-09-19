//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Sample.Configuration.AnotherTypes
{
	/// <summary>
	/// Declares another type config collection provider
	/// </summary>
	public interface IAnotherTypeConfigCollectionProvider
	{
		/// <summary>
		/// Gets another type config collection
		/// </summary>
		/// <returns>another type config collection</returns>
		AnotherTypeConfigCollection GetAnotherTypeConfigCollection();
	}
}
