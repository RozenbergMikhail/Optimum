//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Development;

namespace Platform.Info
{
	/// <summary>
	/// Implements default description provider
	/// </summary>
	public class DescriptionProvider : IDescriptionProvider
	{
		private readonly string description;

		/// <summary>
		/// Creates new instance of <see cref="DescriptionProvider"/>
		/// </summary>
		/// <param name="description">description</param>
		public DescriptionProvider(string description)
		{
			if (description == null)
				throw new MemoryPointerIsNullException("description");

			this.description = description;
		}

		/// <summary>
		/// Gets description of the item
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>description</returns>
		public string GetDescription(Context context)
		{
			return this.description;
		}
	}
}
