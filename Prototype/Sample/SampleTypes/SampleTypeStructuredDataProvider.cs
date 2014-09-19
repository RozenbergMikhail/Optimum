//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Linq;
using System.Collections.Generic;
using Platform.Contexts;
using Platform.ServiceResolvers;
using Platform.UITree;
using Platform.Development;

namespace Sample.SampleTypes
{
	/// <summary>
	/// Implements sample type structured data provider
	/// </summary>
	public class SampleTypeStructuredDataProvider : ISampleTypeStructuredDataProvider
	{
		private readonly IServiceResolver<ISampleTypeSetProvider> setProviderResolver;
		private readonly IServiceResolver<ISampleTypeStructureProvider> structureProviderResolver;

		/// <summary>
		/// Creates new instance of <see cref="SampleTypeStructuredDataProvider"/>
		/// </summary>
		/// <param name="setProviderResolver">set provider resolver</param>
		/// <param name="structureProviderResolver">structure provider resolver</param>
		public SampleTypeStructuredDataProvider(IServiceResolver<ISampleTypeSetProvider> setProviderResolver, IServiceResolver<ISampleTypeStructureProvider> structureProviderResolver)
		{
			if (setProviderResolver == null)
				throw new MemoryPointerIsNullException("setProviderResolver");

			if (structureProviderResolver == null)
				throw new MemoryPointerIsNullException("structureProviderResolver");

			this.setProviderResolver = setProviderResolver;
			this.structureProviderResolver = structureProviderResolver;
		}

		/// <summary>
		/// Lists sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>list of sample type instances</returns>
		public List<SampleType> ListSampleTypes(Context context)
		{
			var setProvider = this.setProviderResolver.GetService(context);
			var structureProvider = this.structureProviderResolver.GetService(context);

			var descriptorsTree = structureProvider.GetSampleTypeDescriptorTree(context);
			var entityRootsTree = UITree
				.Create<string, SampleType>(descriptorsTree, name => setProvider.GetSampleTypeInstanceByName(context, name))
				.GetEntityRootsTree();

			return entityRootsTree.Roots.Select(root => ((EntityTreeNode<SampleType>)root).Entity).ToList();
		}
	}
}
