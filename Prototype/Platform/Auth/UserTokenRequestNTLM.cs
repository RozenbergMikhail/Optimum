//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.Auth
{
	/// <summary>
	/// Contains data for NTLM user token request
	/// </summary>
	public sealed class UserTokenRequestNTLM : UserTokenRequest
	{
		/// <summary>
		/// Creates new instance of <see cref="UserTokenRequestNTLM"/>
		/// </summary>
		public UserTokenRequestNTLM() 
			: base()
		{
		}

		/// <summary>
		/// Creates new instance of <see cref="UserTokenRequestNTLM"/>
		/// </summary>
		/// <param name="tenantName">tenant name</param>
		public UserTokenRequestNTLM(string tenantName)
			: base(tenantName)
		{
		}
	}
}