//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Diagnostics;
using Platform.Contexts;
using Platform.Development;
using Platform.Auth;
using Platform.ServiceResolvers;

namespace Sample.Auth
{
	/// <summary>
	/// Implements sample user token provider
	/// </summary>
	public class SampleUserTokenProvider : IUserTokenProvider
	{
		private readonly IServiceResolver<ISampleUserTokenFactory> sampleUserTokenFactoryResolver;

		/// <summary>
		/// Creates new instance of <see cref="SampleUserTokenProvider"/>
		/// </summary>
		/// <param name="sampleUserTokenFactoryResolver">sample user token factory resolver</param>
		public SampleUserTokenProvider(IServiceResolver<ISampleUserTokenFactory> sampleUserTokenFactoryResolver)
		{
			if (sampleUserTokenFactoryResolver == null)
				throw new MemoryPointerIsNullException("sampleUserTokenFactoryResolver");

			this.sampleUserTokenFactoryResolver = sampleUserTokenFactoryResolver;
		}

		/// <summary>
		/// Gets user token
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userTokenRequest">user token request</param>
		/// <returns>user token</returns>
		public UserToken GetUserToken(Context context, UserTokenRequest userTokenRequest)
		{
			var request = userTokenRequest as UserTokenRequestWithCredentials;
			Debug.Assert(request != null, "request != null");

			var userToken = LoadUserToken(context, request.TenantName, request.AccountName, request.Password);

			return userToken;
		}

		private UserToken LoadUserToken(Context context, string tenantName, string accountName, string password)
		{
			// TODO: implement this function

			var sampleUserTokenFactory = this.sampleUserTokenFactoryResolver.GetService(context);
			var result = sampleUserTokenFactory.CreateUserToken(context, 100);

			return result;
		}
	}
}
