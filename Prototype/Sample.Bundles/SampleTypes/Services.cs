//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.Info;
using Platform.Resx.Info;
using Platform.ServiceResolvers;
using Sample.Configuration.SampleTypes;
using Sample.SampleTypes;

namespace Sample.Bundles.SampleTypes
{
	/// <summary>
	/// Defines bundle of sample type services
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

			var sampleTypeTestErrorFactoryResolver = new ServiceResolver<IInfoEntityFactory<TestError>>(
				new InfoEntityWithDescriptionFactory<TestError>(new ResxDescriptionProvider(Sample.Resx.SampleTypes.Resources.ResourceManager, "SampleType_TestError_Description"), descriptionProvider => new TestError(descriptionProvider)));
			var sampleTypeSetProviderResolver = new ServiceResolver<ISampleTypeSetProvider>(new SampleTypeSetProvider(sampleTypeTestErrorFactoryResolver));
			var sampleTypeStructureProviderResolver = new ServiceResolver<ISampleTypeStructureProvider>(new ConfigFileSampleTypeStructureProvider(sampleFullSectionName));
			var sampleTypeStructuredDataProviderResolver = new ServiceResolver<ISampleTypeStructuredDataProvider>(
				new SampleTypeStructuredDataProvider(sampleTypeSetProviderResolver, sampleTypeStructureProviderResolver));
			this.Bundle.AddServiceResolver(sampleTypeSetProviderResolver);
			this.Bundle.AddServiceResolver(sampleTypeStructureProviderResolver);
			this.Bundle.AddServiceResolver(sampleTypeStructuredDataProviderResolver);
		}
	}
}
