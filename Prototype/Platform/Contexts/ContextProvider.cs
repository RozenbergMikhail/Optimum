//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;
using Platform.Development;
using Platform.ServiceResolvers;

namespace Platform.Contexts
{
	/// <summary>
	/// Implements context provider
	/// </summary>
	public class ContextProvider : IContextProvider
	{
		protected readonly ContextInitData contextInitData;
		protected readonly IServiceResolver<IUserDataProvider> userDataProviderResolver;

		/// <summary>
		/// Creates new instance of <see cref="ContextProvider"/>
		/// </summary>
		/// <param name="contextInitData">context initialization data</param>
		/// <param name="userDataProvider">user data provider</param>
		public ContextProvider(ContextInitData contextInitData, IServiceResolver<IUserDataProvider> userDataProviderResolver)
		{
			if (contextInitData == null)
				throw new MemoryPointerIsNullException("contextInitData");

			if (userDataProviderResolver == null)
				throw new MemoryPointerIsNullException("userDataProviderResolver");

			this.contextInitData = contextInitData;
			this.userDataProviderResolver = userDataProviderResolver;
		}

		/// <summary>
		/// Gets current context
		/// </summary>
		/// <returns>current context</returns>
		public Context GetCurrentContext()
		{
			return new Context(this.contextInitData);
		}

		/// <summary>
		/// Gets current user context
		/// </summary>
		/// <param name="currentUserToken">current user token</param>
		/// <returns>current user context</returns>
		public UserContext GetCurrentUserContext(UserToken currentUserToken)
		{
			var userContextInitData = new UserContextInitData(this.contextInitData)
			{
				CurrentUserToken = currentUserToken,
				UserDataProviderResolver = this.userDataProviderResolver,
			};
			return new UserContext(userContextInitData);
		}
	}
}
