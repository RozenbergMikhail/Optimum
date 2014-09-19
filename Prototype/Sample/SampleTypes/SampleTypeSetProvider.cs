//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;
using Platform.Development;
using Platform.Info;
using Platform.ServiceResolvers;

namespace Sample.SampleTypes
{
	/// <summary>
	/// Implements sample type set provider
	/// </summary>
	public class SampleTypeSetProvider : ISampleTypeSetProvider
	{
		private readonly Dictionary<string, SampleType> sampleTypes;

		/// <summary>
		/// Creates new instance of <see cref="SampleTypeSetProvider"/>
		/// </summary>
		/// <param name="testErrorFactoryResolver">test error factory resolver</param>
		public SampleTypeSetProvider(IServiceResolver<IInfoEntityFactory<TestError>> testErrorFactoryResolver)
		{
			if (testErrorFactoryResolver == null)
				throw new MemoryPointerIsNullException("testErrorFactoryResolver");

			this.sampleTypes = LoadSampleTypes(testErrorFactoryResolver);
		}

		/// <summary>
		/// Gets sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>sample type instances</returns>
		public IEnumerable<SampleType> GetSampleTypeInstances(Context context)
		{
			return this.sampleTypes.Values;
		}

		/// <summary>
		/// Gets sample type instance by name
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="name">name</param>
		/// <returns>sample type instance</returns>
		public SampleType GetSampleTypeInstanceByName(Context context, string name)
		{
			SampleType result;
			this.sampleTypes.TryGetValue(name, out result);
			return result;
		}

		private static Dictionary<string, SampleType> LoadSampleTypes(IServiceResolver<IInfoEntityFactory<TestError>> testErrorFactoryResolver)
		{
			var result = new Dictionary<string, SampleType>();
			result.Add("First name", new SampleType(new SampleTypeInitData() {
				Name = "First name",
				Count = 1,
				TestErrorFactoryResolver = testErrorFactoryResolver,
			}));
			result.Add("Second name", new SampleType(new SampleTypeInitData() {
				Name = "Second name", 
				Count = 2,
				TestErrorFactoryResolver = testErrorFactoryResolver,
			}));
			return result;
		}
	}
}
