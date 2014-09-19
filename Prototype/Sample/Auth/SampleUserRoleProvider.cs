//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using Platform.Contexts;
using Platform.Auth;

namespace Sample.Auth
{
	/// <summary>
	/// Implements sample user role provider
	/// </summary>
	public class SampleUserRoleProvider : IUserRoleProvider<SampleUserRole>
	{
		private readonly Dictionary<SampleUserRole, Func<UserContext, bool>> roleCheckFunctions;

		/// <summary>
		/// Creates new instance of <see cref="SampleUserRoleProvider"/>
		/// </summary>
		public SampleUserRoleProvider()
		{
			this.roleCheckFunctions = LoadRoleCheckFunctions();
		}

		#region IUserRoleProvider members

		/// <summary>
		/// Gets user roles for the specified user
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <returns>user roles</returns>
		public IEnumerable<SampleUserRole> GetUserRoles(UserContext userContext)
		{
			var result = new List<SampleUserRole>();

			foreach (var role in this.roleCheckFunctions.Keys)
			{
				var roleCheckFunction = this.roleCheckFunctions[role];
				if (roleCheckFunction(userContext) == true)
				{
					result.Add(role);
				}
			}

			return result;
		}

		/// <summary>
		/// Gets a value indication whether the specified user has the specified role
		/// </summary>
		/// <param name="userContext">user context</param>
		/// <param name="role">role</param>
		/// <returns>true, if user has the specified role; otherwise, false</returns>
		public bool CheckUserHasRole(UserContext userContext, SampleUserRole role)
		{
			var result = false;

			Func<UserContext, bool> roleCheckFunction;
			if (this.roleCheckFunctions.TryGetValue(role, out roleCheckFunction))
			{
				result = roleCheckFunction(userContext);
			}

			return result;
		}

		#endregion

		#region Helper methods

		private static Dictionary<SampleUserRole, Func<UserContext, bool>> LoadRoleCheckFunctions()
		{
			var result = new Dictionary<SampleUserRole, Func<UserContext, bool>>();
			result.Add(SampleUserRole.Anonymous, CheckAnonymous);
			result.Add(SampleUserRole.Admin, CheckAdmin);
			result.Add(SampleUserRole.User, CheckUser);
			return result;
		}

		private static bool CheckAnonymous(UserContext userContext)
		{
			return userContext.GetCurrentUser<SampleUserData>().UserId == 0;
		}

		private static bool CheckUser(UserContext userContext)
		{
			return userContext.GetCurrentUser<SampleUserData>().UserId != 0;
		}

		private static bool CheckAdmin(UserContext userContext)
		{
			var userData = userContext.GetCurrentUser<SampleUserData>();
			return userData.UserId != 0 && userData.Surname.StartsWith("TEST");
		}

		#endregion
	}
}
