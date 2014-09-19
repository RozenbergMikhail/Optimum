//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.ServiceResolvers;
using Platform.UITree;
using Platform.Development;

namespace Sample.AnotherTypes
{
	/// <summary>
	/// Implements another sample type structured data provider
	/// </summary>
	public class AnotherTypeStructuredDataProvider : IAnotherTypeStructuredDataProvider
	{
		private readonly IServiceResolver<IAnotherTypeSetProvider> setProviderResolver;
		private readonly IServiceResolver<IAnotherTypeStructureProvider> structureProviderResolver;

		/// <summary>
		/// Creates new instance of <see cref="AnotherTypeStructuredDataProvider"/>
		/// </summary>
		/// <param name="setProviderResolver">instances provider resolver</param>
		/// <param name="structureProviderResolver">structure provider resolver</param>
		public AnotherTypeStructuredDataProvider(IServiceResolver<IAnotherTypeSetProvider> setProviderResolver, IServiceResolver<IAnotherTypeStructureProvider> structureProviderResolver)
		{
			if (setProviderResolver == null)
				throw new MemoryPointerIsNullException("setProviderResolver");

			if (structureProviderResolver == null)
				throw new MemoryPointerIsNullException("structureProviderResolver");

			this.setProviderResolver = setProviderResolver;
			this.structureProviderResolver = structureProviderResolver;
		}

		/// <summary>
		/// Gets another sample type structured data
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>another sample type structured data</returns>
		public UITree GetAnotherTypeStructuredData(Context context)
		{
			var setProvider = this.setProviderResolver.GetService(context);
			var structureProvider = this.structureProviderResolver.GetService(context);

			var descriptorTree = structureProvider.GetAnotherTypeDescriptorTree(context);
			return UITree.Create<string, AnotherType>(descriptorTree, name => setProvider.GetAnotherTypeInstanceByName(context, name));
		}
	}
}
