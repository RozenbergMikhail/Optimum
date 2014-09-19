//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Resources;
using Platform.Contexts;
using Platform.Development;
using Platform.OutputStrings;

namespace Platform.Resx.OutputStrings
{
	/// <summary>
	/// Implements output string Resx source
	/// </summary>
	public class ResxOutputStringSource : OutputStringSource
	{
		private readonly ResourceManager resourceManager;

		/// <summary>
		/// Creates new instance of <see cref="ResxOutputStringSource"/>
		/// </summary>
		/// <param name="resourceManager">resource manager instance</param>
		public ResxOutputStringSource(ResourceManager resourceManager) : base()
		{
			if (resourceManager == null)
				throw new MemoryPointerIsNullException("resourceManager");

			this.resourceManager = resourceManager;
		}

		/// <summary>
		/// Loads output string by key with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="key">output string key</param>
		/// <returns>output string</returns>
		protected override string LoadOutputString(Context context, string key)
		{
			return this.resourceManager.GetString(key, context.GetCurrentUICulture());
		}
	}
}