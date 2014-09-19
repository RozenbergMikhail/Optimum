//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.Info
{
	/// <summary>
	/// Declares info entity factory methods
	/// </summary>
	/// <typeparam name="T">info entity type</typeparam>
	public interface IInfoEntityFactory<out T> where T : InfoEntity
	{
		/// <summary>
		/// Creates info entity
		/// </summary>
		/// <returns>info entity</returns>
		T CreateInfoEntity();
	}
}