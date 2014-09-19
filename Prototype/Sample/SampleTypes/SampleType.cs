//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Development;
using Platform.Entities;
using Platform.Info;
using Platform.ServiceResolvers;

namespace Sample.SampleTypes
{
	/// <summary>
	/// Contains sample type data
	/// </summary>
	public class SampleType : Entity
	{
		private readonly IServiceResolver<IInfoEntityFactory<TestError>> testErrorFactoryResolver;

		/// <summary>
		/// Creates new instance of <see cref="SampleType"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		internal SampleType(SampleTypeInitData initData)
		{
			if (initData == null)
				throw new MemoryPointerIsNullException("initData");

			initData.ValidatePropertiesNotNull();

			this.Name = initData.Name;
			this.Count = initData.Count;
			this.testErrorFactoryResolver = initData.TestErrorFactoryResolver;
		}

		/// <summary>
		/// Gets name
		/// </summary>
		public string Name
		{
			get; 
			private set;
		}

		/// <summary>
		/// Gets count
		/// </summary>
		public int Count
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets string description of an object with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>string representation</returns>
		public override string GetObjectDescription(Context context)
		{
			return string.Format("Name='{0}'; Count={1}", this.Name, this.Count);
		}

		/// <summary>
		/// Gets exception for the case when argument is null
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>exception instance</returns>
		public EntityException<SampleType, TestError> GetTestErrorException(Context context)
		{
			var testErrorFactory = testErrorFactoryResolver.GetService(context);
			return new EntityException<SampleType, TestError>(context, this, testErrorFactory.CreateInfoEntity());
		}
	}
}
