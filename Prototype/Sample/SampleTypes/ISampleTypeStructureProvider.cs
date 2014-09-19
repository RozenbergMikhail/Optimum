//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.UITree;

namespace Sample.SampleTypes
{
	/// <summary>
	/// Declares sample type structure provider
	/// </summary>
	public interface ISampleTypeStructureProvider
	{
		/// <summary>
		/// Gets sample type descriptor tree
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>sample type descriptors tree</returns>
		IUITree GetSampleTypeDescriptorTree(Context context);
	}
}
