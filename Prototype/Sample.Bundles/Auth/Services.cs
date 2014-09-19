//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;
using Platform.Development;
using Platform.ServiceResolvers;
using Platform.System;
using Sample.Auth;

namespace Sample.Bundles.Auth
{
	/// <summary>
	/// Defines bundle of sample auth services
	/// </summary>
	public class Services : ServiceBundleWrapper
	{

		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		/// <param name="utcTimeProviderResolver">UTC time provider resolver</param>
		public Services(IServiceResolver<IUTCTimeProvider> utcTimeProviderResolver)
		{
			if (utcTimeProviderResolver == null)
				throw new MemoryPointerIsNullException("utcTimeProviderResolver");

			var sampleUserTokenFactoryResolver = new ServiceResolver<ISampleUserTokenFactory>(new SampleUserTokenFactory(utcTimeProviderResolver));
			var userTokenProviderResolver = new ServiceResolver<IUserTokenProvider>(new SampleUserTokenProvider(sampleUserTokenFactoryResolver));
			var userDataProviderResolver = new ServiceResolver<IUserDataProvider>(new SampleUserDataProvider());
			var currentUserTokenProviderResolver = new ServiceResolver<ICurrentUserTokenProvider>(new SampleCurrentUserTokenProvider());
			this.Bundle.AddServiceResolver(sampleUserTokenFactoryResolver);
			this.Bundle.AddServiceResolver(userTokenProviderResolver);
			this.Bundle.AddServiceResolver(userDataProviderResolver);
			this.Bundle.AddServiceResolver(currentUserTokenProviderResolver);
		}
	}
}
