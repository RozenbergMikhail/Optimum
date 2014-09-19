//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using System.Diagnostics;

using Platform.Auth;
using Platform.Contexts;

namespace Sample.Auth
{
	/// <summary>
	/// Implements sample user data provider
	/// </summary>
	public class SampleUserDataProvider : IUserDataProvider
	{
		private readonly Dictionary<int, UserData> userData; // TODO: substitute int for UserToken here (after making UserToken implement IComparable)

		/// <summary>
		/// Creates new instance of <see cref="SampleUserDataProvider"/>
		/// </summary>
		public SampleUserDataProvider()
		{
			this.userData = LoadUserData();
		}

		/// <summary>
		/// Gets user data by user token
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userToken">user token</param>
		/// <returns>user data</returns>
		public UserData GetUserData(Context context, UserToken userToken)
		{
			int userId = 0;

			if (!(userToken is AnonymousUserToken))
			{
				var token = userToken as SampleUserToken;
				Debug.Assert(token != null, "token != null");

				userId = token.UserId;
			}

			return this.userData[userId];
		}

		private Dictionary<int, UserData> LoadUserData()
		{
			// TODO: load surname (and possibly other user data) from some storage

			var result = new Dictionary<int, UserData>();

			result.Add(0, new SampleUserData(0, "ANONYMOUS USER"));
			result.Add(100, new SampleUserData(100, "TEST SURNAME"));
			result.Add(101, new SampleUserData(101, "ANOTHER SURNAME"));

			return result;
		}
	}
}
