//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.ServiceResolvers;
using Sample.Delegates;

namespace Sample.Bundles.Delegates
{
	/// <summary>
	/// Defines bundle of sample delegate services
	/// </summary>
	public class Services : ServiceBundleWrapper
	{
		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		public Services()
		{
			var delegateProviderResolver = new ServiceResolver<IDelegateProvider>(new DelegateProvider());
			this.Bundle.AddServiceResolver(delegateProviderResolver);
		}
	}
}
