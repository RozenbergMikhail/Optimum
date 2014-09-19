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
	/// Contains user context initialization data
	/// </summary>
	public class UserContextInitData : ContextInitData
	{
		/// <summary>
		/// Creates new instance of <see cref="UserContextInitData"/>
		/// </summary>
		/// <param name="contextInitData">context init data</param>
		public UserContextInitData(ContextInitData contextInitData)
			: base(contextInitData)
		{
		}

		/// <summary>
		/// Gets or sets current user token
		/// </summary>
		public UserToken CurrentUserToken
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets user data provider resolver
		/// </summary>
		public IServiceResolver<IUserDataProvider> UserDataProviderResolver
		{
			get;
			set;
		}

		/// <summary>
		/// Validates initialization data
		/// </summary>
		public override void ValidatePropertiesNotNull()
		{
			base.ValidatePropertiesNotNull();

			if (this.CurrentUserToken == null)
				throw new MemoryPointerIsNullException("CurrentUserToken");

			if (this.UserDataProviderResolver == null)
				throw new MemoryPointerIsNullException("UserDataProviderResolver");
		}
	}
}
