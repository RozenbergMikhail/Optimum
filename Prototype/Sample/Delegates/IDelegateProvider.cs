//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
namespace Sample.Delegates
{
	/// <summary>
	/// Declares delegate provider methods
	/// </summary>
	public interface IDelegateProvider
	{
		/// <summary>
		/// Gets delegate
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="delegateId">delegate identifier</param>
		/// <returns>delegate</returns>
		Delegate GetDelegate(Context context, int delegateId);
	}
}
