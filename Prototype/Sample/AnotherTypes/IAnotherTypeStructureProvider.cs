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
	/// Declares another sample type structure provider
	/// </summary>
	public interface IAnotherTypeStructureProvider
	{
		/// <summary>
		/// Gets another sample type descriptor tree
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>another sample type descriptors tree</returns>
		IUITree GetAnotherTypeDescriptorTree(Context context);
	}
}
