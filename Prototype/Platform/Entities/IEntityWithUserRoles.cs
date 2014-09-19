//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using Platform.Contexts;

namespace Platform.Entities
{
	/// <summary>
	/// Declares interface of an entity with formalized user roles
	/// </summary>
	/// <typeparam name="TEntityUserRoleEnum">entity user role enum type</typeparam>
	public interface IEntityWithUserRoles<TEntityUserRoleEnum> 
		where TEntityUserRoleEnum : struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets entity user roles for the specified user in the current entity state
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <returns>entity user roles</returns>
		IEnumerable<TEntityUserRoleEnum> GetEntityUserRoles(UserContext userContext);

		/// <summary>
		/// Gets a value indication whether the specified user has the specified entity role for the current entity
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <param name="entityRole">entity role</param>
		/// <returns>true, if user has the specified entity role; otherwise, false</returns>
		bool CheckUserHasEntityRole(UserContext userContext, TEntityUserRoleEnum entityRole);
	}
}
