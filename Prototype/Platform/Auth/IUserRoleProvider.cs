//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using Platform.Contexts;

namespace Platform.Auth
{
	/// <summary>
	/// Declares user role provider
	/// </summary>
	/// <typeparam name="TUserRoleEnum">user role enum type</typeparam>
	public interface IUserRoleProvider<TUserRoleEnum>
		where TUserRoleEnum : struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets user roles for the specified user
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <returns>user roles</returns>
		IEnumerable<TUserRoleEnum> GetUserRoles(UserContext userContext);

		/// <summary>
		/// Gets a value indication whether the specified user has the specified role
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <param name="role">role</param>
		/// <returns>true, if user has the specified role; otherwise, false</returns>
		bool CheckUserHasRole(UserContext userContext, TUserRoleEnum role);
	}
}
