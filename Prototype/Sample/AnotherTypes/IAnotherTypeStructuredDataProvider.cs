//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.UITree;

namespace Sample.AnotherTypes
{
	/// <summary>
	/// Declares another sample type structured data provider
	/// </summary>
	public interface IAnotherTypeStructuredDataProvider
	{
		/// <summary>
		/// Gets another sample type structured data
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>another sample type structured data</returns>
		UITree GetAnotherTypeStructuredData(Context context);
	}
}
