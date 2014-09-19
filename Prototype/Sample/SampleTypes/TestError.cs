//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Info;

namespace Sample.SampleTypes
{
	/// <summary>
	/// Defines sample type test error info
	/// </summary>
	public class TestError : InfoEntityWithDescription
	{
		/// <summary>
		/// Creates new instance of <see cref="TestError"/>
		/// </summary>
		/// <param name="descriptionProvider">description provider</param>
		public TestError(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
		{
		}
	}
}