//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Platform.Info
{
	/// <summary>
	/// Declares description provider
	/// </summary>
	public interface IDescriptionProvider
	{
		/// <summary>
		/// Gets description of the item
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>description</returns>
		string GetDescription(Context context);
	}
}
