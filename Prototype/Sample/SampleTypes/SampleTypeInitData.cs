//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.Info;
using Platform.ServiceResolvers;

namespace Sample.SampleTypes
{
	/// <summary>
	/// Contains sample type initialization data
	/// </summary>
	public class SampleTypeInitData
	{
		/// <summary>
		/// Gets or sets name
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets count
		/// </summary>
		public int Count
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets test error factory resolver
		/// </summary>
		public IServiceResolver<IInfoEntityFactory<TestError>> TestErrorFactoryResolver
		{
			get;
			set;
		}

		/// <summary>
		/// Validates initialization data
		/// </summary>
		public virtual void ValidatePropertiesNotNull()
		{
			if (this.TestErrorFactoryResolver == null)
				throw new MemoryPointerIsNullException("TestErrorFactoryResolver");
		}
	}
}
