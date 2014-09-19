//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Development;
using Platform.ServiceResolvers;
using Platform.System;

namespace Sample.Auth
{
	/// <summary>
	/// Implements sample user token factory
	/// </summary>
	public class SampleUserTokenFactory : ISampleUserTokenFactory
	{
		private readonly IServiceResolver<IUTCTimeProvider> utcTimeProviderResolver;

		/// <summary>
		/// Creates new instance of <see cref="SampleUserTokenFactory"/>
		/// </summary>
		/// <param name="utcTimeProviderResolver">UTC time provider resolver</param>
		public SampleUserTokenFactory(IServiceResolver<IUTCTimeProvider> utcTimeProviderResolver)
		{
			if (utcTimeProviderResolver == null)
				throw new MemoryPointerIsNullException("utcTimeProviderResolver");

			this.utcTimeProviderResolver = utcTimeProviderResolver;
		}

		/// <summary>
		/// Creates sample user token
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <returns>sample user token</returns>
		public SampleUserToken CreateUserToken(Context context, int userId)
		{
			if (context == null)
				throw new MemoryPointerIsNullException("context");

			return new SampleUserToken(userId, utcTimeProviderResolver.GetService(context).GetCurrentUTCTime());
		}
	}
}
