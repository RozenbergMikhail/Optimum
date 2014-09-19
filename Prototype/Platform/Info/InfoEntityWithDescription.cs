//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Platform.Info
{
	/// <summary>
	/// Defines base class for info entities with description
	/// </summary>
	public abstract class InfoEntityWithDescription : InfoEntity, IDescriptionProvider
	{
		private readonly IDescriptionProvider descriptionProvider;

		/// <summary>
		/// Creates new instance of <see cref="InfoEntityWithDescription"/>
		/// </summary>
		/// <param name="descriptionProvider">description provider</param>
		protected InfoEntityWithDescription(IDescriptionProvider descriptionProvider)
		{
			this.descriptionProvider = descriptionProvider;
		}

		/// <summary>
		/// Gets description of the item
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>description</returns>
		public string GetDescription(Context context)
		{
			return this.descriptionProvider.GetDescription(context);
		}

		/// <summary>
		/// Gets string description of an object with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>string representation</returns>
		public override string GetObjectDescription(Context context)
		{
			return GetDescription(context);
		}
	}
}
