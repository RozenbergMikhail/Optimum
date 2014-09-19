//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Development;
using Platform.Auth;

namespace Platform.Contexts
{
	/// <summary>
	/// Contains user context snapshot data
	/// </summary>
	public class UserContextSnapshot : ContextSnapshot
	{
		/// <summary>
		/// Creates new instance of <see cref="UserContextSnapshot"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public UserContextSnapshot(UserContextSnapshotInitData initData) : base(initData)
		{
			this.UserData = initData.UserData;
		}

		/// <summary>
		/// Gets UTC time
		/// </summary>
		public UserData UserData
		{
			get;
			private set;
		}
	}
}
