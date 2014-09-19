//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.Auth
{
	/// <summary>
	/// Defines base class for user token requests
	/// </summary>
	public abstract class UserTokenRequest
	{
		/// <summary>
		/// Creates new instance of <see cref="UserTokenRequest"/>
		/// </summary>
		protected UserTokenRequest()
		{
			this.TenantName = String.Empty;
		}

		/// <summary>
		/// Creates new instance of <see cref="UserTokenRequest"/>
		/// </summary>
		/// <param name="tenantName">tenant name</param>
		protected UserTokenRequest(string tenantName)
		{
			this.TenantName = tenantName;
		}

		/// <summary>
		/// Gets tenant name
		/// </summary>
		public string TenantName
		{
			get; 
			private set; 
		}
	}
}