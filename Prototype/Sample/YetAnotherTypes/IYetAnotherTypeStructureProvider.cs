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
	/// Declares yet another sample type structure provider
	/// </summary>
	public interface IYetAnotherTypeStructureProvider
	{
		/// <summary>
		/// Gets yet another sample type descriptor tree
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>yet another sample type descriptors tree</returns>
		IUITree GetYetAnotherTypeDescriptorTree(Context context);
	}
}
