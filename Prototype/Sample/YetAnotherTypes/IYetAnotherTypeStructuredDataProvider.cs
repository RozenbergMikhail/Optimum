//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.UITree;

namespace Sample.YetAnotherTypes
{
	/// <summary>
	/// Declares yet another sample type structured data provider
	/// </summary>
	public interface IYetAnotherTypeStructuredDataProvider
	{
		/// <summary>
		/// Gets yet another sample type structured data
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>yet another sample type structured data</returns>
		UITree GetYetAnotherTypeStructuredData(Context context);
	}
}
