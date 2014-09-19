//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Development;

namespace Platform.Info
{
	/// <summary>
	/// Implements info entity with description factory methods
	/// </summary>
	/// <typeparam name="T">info entity type</typeparam>
	public class InfoEntityWithDescriptionFactory<T> : IInfoEntityFactory<T> where T : InfoEntityWithDescription
	{
		private readonly IDescriptionProvider descriptionProvider;
		private readonly Func<IDescriptionProvider, T> infoEntityConstructor;

		/// <summary>
		/// Creates new instance of <see cref="InfoEntityWithDescriptionFactory{T}"/>
		/// </summary>
		/// <param name="descriptionProvider">description provider</param>
		/// <param name="infoEntityConstructor">info entity constructor</param>
		public InfoEntityWithDescriptionFactory(IDescriptionProvider descriptionProvider, Func<IDescriptionProvider, T> infoEntityConstructor)
		{
			if (descriptionProvider == null)
				throw new MemoryPointerIsNullException("descriptionProvider");

			if (infoEntityConstructor == null)
				throw new MemoryPointerIsNullException("infoEntityConstructor");

			this.descriptionProvider = descriptionProvider;
			this.infoEntityConstructor = infoEntityConstructor;
		}

		/// <summary>
		/// Creates info entity
		/// </summary>
		/// <returns>info entity</returns>
		public T CreateInfoEntity()
		{
			return this.infoEntityConstructor(this.descriptionProvider);
		}
	}
}