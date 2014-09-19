//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Auth;

namespace Sample.Auth
{
	/// <summary>
	/// Contains sample user token
	/// </summary>
	public sealed class SampleUserToken : UserToken
	{
		/// <summary>
		/// Creates new instance of <see cref="SampleUserToken"/>
		/// </summary>
		/// <param name="userId">user identifier</param>
		/// <param name="issuedAt">date/time when token was issued</param>
		public SampleUserToken(int userId, DateTime issuedAt)
		{
			this.UserId = userId;
			this.IssuedAt = issuedAt;
		}

		/// <summary>
		/// Gets user identifier
		/// </summary>
		public int UserId
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets when token was issued
		/// </summary>
		public DateTime IssuedAt
		{
			get;
			private set;
		}
	}
}