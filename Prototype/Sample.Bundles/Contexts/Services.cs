//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;
using Platform.Contexts;
using Platform.Development;
using Platform.ServiceResolvers;
using Sample.Contexts;
using Sample.Meetings;

namespace Sample.Bundles.Contexts
{
	/// <summary>
	/// Defines bundle of sample context services
	/// </summary>
	public class Services : ServiceBundleWrapper
	{
		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		/// <param name="contextInitData">context initialization data</param>
		/// <param name="userDataProviderResolver">user data provider resolver</param>
		/// <param name="meetingProviderResolver">meeting provider resolver</param>
		public Services(ContextInitData contextInitData, IServiceResolver<IUserDataProvider> userDataProviderResolver, IServiceResolver<IMeetingProvider> meetingProviderResolver)
		{
			if (contextInitData == null)
				throw new MemoryPointerIsNullException("contextInitData");

			if (userDataProviderResolver == null)
				throw new MemoryPointerIsNullException("userDataProviderResolver");

			if (meetingProviderResolver == null)
				throw new MemoryPointerIsNullException("meetingProviderResolver");

			var contextProvider = new SampleContextProvider(contextInitData, userDataProviderResolver, meetingProviderResolver);
			this.Bundle.AddServiceResolver(new ServiceResolver<ISampleContextProvider>(contextProvider));
		}
	}
}
