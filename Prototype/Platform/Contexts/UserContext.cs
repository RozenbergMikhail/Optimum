//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Abstractions;
using Platform.Auth;
using Platform.ServiceResolvers;

namespace Platform.Contexts
{
	/// <summary>
	/// Contains user context data
	/// </summary>
	public class UserContext : Context
	{
		private readonly IServiceResolver<IUserDataProvider> userDataProviderResolver;
		private readonly SingletonVariable<UserData> currentUserData;
		
		/// <summary>
		/// Creates new instance of <see cref="UserContext"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public UserContext(UserContextInitData initData)
			: base(initData)
		{
			this.CurrentUserToken = initData.CurrentUserToken;
			this.userDataProviderResolver = initData.UserDataProviderResolver;
			this.currentUserData = new SingletonVariable<UserData>(() => this.LoadUserData(this.CurrentUserToken));
		}

		/// <summary>
		/// Gets current user token
		/// </summary>
		public UserToken CurrentUserToken
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets current user token converted to the specified type
		/// </summary>
		/// <typeparam name="T">token type</typeparam>
		/// <returns>current user token</returns>
		public T GetCurrentUserToken<T>() where T : UserToken
		{
			return (T) this.CurrentUserToken;
		}
		
		/// <summary>
		/// Gets current user associated with the context
		/// </summary>
		/// <typeparam name="T">type</typeparam>
		/// <returns>current user data</returns>
		public T GetCurrentUser<T>() where T: UserData
		{
			return (T) this.currentUserData.Value;
		}

		/// <summary>
		/// Loads user data by user token
		/// </summary>
		/// <param name="userToken">user token</param>
		/// <returns>user data</returns>
		protected virtual UserData LoadUserData(UserToken userToken)
		{
			// TODO: can implement caching here
			return this.userDataProviderResolver.GetService(this).GetUserData(this, userToken);
		}

		/// <summary>
		/// Gets context snapshot
		/// </summary>
		/// <returns>context snapshot</returns>
		public override ContextSnapshot GetSnapshot()
		{
			var snapshotInitData = new UserContextSnapshotInitData()
			{
				UTCTime = this.GetCurrentTimeUTC(),
				LocalTimeOffset = this.GetLocalTimeOffset(),
				UICulture = this.GetCurrentUICulture(),
				UserData = this.currentUserData.Value,
			};

			return new ContextSnapshot(snapshotInitData);
		}
	}
}
