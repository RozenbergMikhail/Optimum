//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.ServiceResolvers;
using Sample.AnotherTypes;
using Sample.Configuration.AnotherTypes;

namespace Sample.Bundles.AnotherTypes
{
	/// <summary>
	/// Defines bundle of another type services
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

			var anotherTypeSetProviderResolver = new ServiceResolver<IAnotherTypeSetProvider>(new AnotherTypeSetProvider());
			var anotherTypeStructureProviderResolver = new ServiceResolver<IAnotherTypeStructureProvider>(new ConfigFileAnotherTypeStructureProvider(sampleFullSectionName));
			var anotherTypeStructuredDataProviderResolver = new ServiceResolver<IAnotherTypeStructuredDataProvider>(
				new AnotherTypeStructuredDataProvider(anotherTypeSetProviderResolver, anotherTypeStructureProviderResolver));
			this.Bundle.AddServiceResolver(anotherTypeSetProviderResolver);
			this.Bundle.AddServiceResolver(anotherTypeStructureProviderResolver);
			this.Bundle.AddServiceResolver(anotherTypeStructuredDataProviderResolver);
		}
	}
}
