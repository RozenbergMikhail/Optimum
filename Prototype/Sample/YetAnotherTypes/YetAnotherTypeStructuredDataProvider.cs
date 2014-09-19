//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Development;
using Platform.ServiceResolvers;
using Platform.UITree;

namespace Sample.YetAnotherTypes
{
	/// <summary>
	/// Implements yet another sample type structured data provider
	/// </summary>
	public class YetAnotherTypeStructuredDataProvider : IYetAnotherTypeStructuredDataProvider
	{
		private readonly IServiceResolver<IYetAnotherTypeSetProvider> setProviderResolver;
		private readonly IServiceResolver<IYetAnotherTypeStructureProvider> structureProviderResolver;

		/// <summary>
		/// Creates new instance of <see cref="YetAnotherTypeStructuredDataProvider"/>
		/// </summary>
		/// <param name="setProviderResolver">set provider resolver</param>
		/// <param name="structureProviderResolver">structure provider resolver</param>
		public YetAnotherTypeStructuredDataProvider(IServiceResolver<IYetAnotherTypeSetProvider> setProviderResolver, IServiceResolver<IYetAnotherTypeStructureProvider> structureProviderResolver)
		{
			if (setProviderResolver == null)
				throw new MemoryPointerIsNullException("setProviderResolver");

			if (structureProviderResolver == null)
				throw new MemoryPointerIsNullException("structureProviderResolver");

			this.setProviderResolver = setProviderResolver;
			this.structureProviderResolver = structureProviderResolver;
		}

		/// <summary>
		/// Gets yet another sample type structured data
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>yet another sample type structured data</returns>
		public UITree GetYetAnotherTypeStructuredData(Context context)
		{
			var setProvider = setProviderResolver.GetService(context);
			var structureProvider = structureProviderResolver.GetService(context);

			var descriptorTree = structureProvider.GetYetAnotherTypeDescriptorTree(context);
			return UITree.Create<string, YetAnotherType>(descriptorTree, name => setProvider.GetYetAnotherTypeInstanceByName(context, name));
		}
	}
}
