//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.ServiceResolvers;
using Sample.Configuration.YetAnotherTypes;
using Sample.YetAnotherTypes;

namespace Sample.Bundles.YetAnotherTypes
{
	/// <summary>
	/// Defines bundle of yet another type services
	/// </summary>
	public class Services : ServiceBundleWrapper
	{
		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		/// <param name="sampleFullSectionName">sample full section name</param>
		public Services(string sampleFullSectionName)
		{
			if (sampleFullSectionName == null)
				throw new MemoryPointerIsNullException("sampleFullSectionName");

			var yetAnotherTypeSetProviderResolver = new ServiceResolver<IYetAnotherTypeSetProvider>(new YetAnotherTypeSetProvider());
			var yetAnotherTypeStructureProviderResolver = new ServiceResolver<IYetAnotherTypeStructureProvider>(new ConfigFileYetAnotherTypeStructureProvider(sampleFullSectionName));
			var yetAnotherTypeStructuredDataProviderResolver = new ServiceResolver<IYetAnotherTypeStructuredDataProvider>(
				new YetAnotherTypeStructuredDataProvider(yetAnotherTypeSetProviderResolver, yetAnotherTypeStructureProviderResolver));

			this.Bundle.AddServiceResolver(yetAnotherTypeSetProviderResolver);
			this.Bundle.AddServiceResolver(yetAnotherTypeStructureProviderResolver);
			this.Bundle.AddServiceResolver(yetAnotherTypeStructuredDataProviderResolver);
		}
	}
}
