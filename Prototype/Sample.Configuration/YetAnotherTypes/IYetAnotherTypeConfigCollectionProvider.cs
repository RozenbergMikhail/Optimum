//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Configuration.UITree;

namespace Sample.Configuration.YetAnotherTypes
{
	/// <summary>
	/// Declares yet another type config collection provider
	/// </summary>
	public interface IYetAnotherTypeConfigCollectionProvider
	{
		/// <summary>
		/// Gets yet another type config collection
		/// </summary>
		/// <returns>yet another type config collection</returns>
		TreeStructuredTypeConfigCollection GetYetAnotherTypeConfigCollection();
	}
}
