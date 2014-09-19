//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.Auth
{
	/// <summary>
	/// Contains credentials data for user token requests
	/// </summary>
	public sealed class UserTokenRequestWithCredentials : UserTokenRequest
	{
		/// <summary>
		/// Creates new instance of <see cref="UserTokenRequestWithCredentials"/>
		/// </summary>
		/// <param name="accountName">user account name</param>
		/// <param name="password">user password</param>
		public UserTokenRequestWithCredentials(string accountName, string password) 
			: base()
		{
			this.AccountName = accountName;
			this.Password = password;
		}

		/// <summary>
		/// Creates new instance of <see cref="UserTokenRequestWithCredentials"/>
		/// </summary>
		/// <param name="tenantName">tenant name</param>
		/// <param name="accountName">user account name</param>
		/// <param name="password">user password</param>
		public UserTokenRequestWithCredentials(string tenantName, string accountName, string password)
			: base(tenantName)
		{
			this.AccountName = accountName;
			this.Password = password;
		}

		/// <summary>
		/// Gets or sets user account name
		/// </summary>
		public string AccountName
		{
			get; 
			private set; 
		}

		/// <summary>
		/// Gets or user password
		/// </summary>
		public string Password 
		{ 
			get; 
			private set; 
		}
	}
}