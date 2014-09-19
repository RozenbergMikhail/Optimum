//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Sample.Auth
{
	/// <summary>
	/// Enumerates possible global user roles
	/// </summary>
	public enum SampleUserRole
	{
		/// <summary>
		/// All user roles
		/// </summary>
		All = 0,

		/// <summary>
		/// Authenticated users
		/// </summary>
		Authenticated = 1,

		/// <summary>
		/// Ordinary user
		/// </summary>
		User = 2,

		/// <summary>
		/// Admin user
		/// </summary>
		Admin = 3,

		/// <summary>
		/// Anonymous user
		/// </summary>
		Anonymous = 4,
	}
}
