//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.Auth
{
	/// <summary>
	/// Defines anonymous user token
	/// </summary>
	public sealed class AnonymousUserToken : UserToken
	{
		private static readonly AnonymousUserToken instance = new AnonymousUserToken();

		/// <summary>
		/// Creates new instance of <see cref="AnonymousUserToken"/>
		/// </summary>
		private AnonymousUserToken()
		{
		}

		/// <summary>
		/// Gets anonymous user token instance
		/// </summary>
		public static AnonymousUserToken Instance
		{
			get
			{
				return instance;
			}
		}
	}
}