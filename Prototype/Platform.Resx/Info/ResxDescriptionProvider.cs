//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Resources;
using Platform.Contexts;
using Platform.Info;

namespace Platform.Resx.Info
{
	/// <summary>
	/// Defines resx-based description provider
	/// </summary>
	public class ResxDescriptionProvider : IDescriptionProvider
	{
		private readonly ResourceManager resourceManager;
		private readonly string resourceKey;

		/// <summary>
		/// Creates new instance of <see cref="ResxDescriptionProvider"/>
		/// </summary>
		/// <param name="resourceManager">resource manager</param>
		/// <param name="resourceKey">resource key</param>
		public ResxDescriptionProvider(ResourceManager resourceManager, string resourceKey)
		{
			this.resourceManager = resourceManager;
			this.resourceKey = resourceKey;
		}

		/// <summary>
		/// Gets description of the item
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>description</returns>
		public string GetDescription(Context context)
		{
			return this.resourceManager.GetString(resourceKey, context.GetCurrentUICulture());
		}
	}
}