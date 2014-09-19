//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Abstractions;
using Platform.Contexts;

namespace Platform.Auth
{
	/// <summary>
	/// Declares user role tree provider
	/// </summary>
	/// <typeparam name="TUserRoleEnum">user role enum type</typeparam>
	public interface IUserRoleTreeProvider<TUserRoleEnum>
		where TUserRoleEnum : struct, IConvertible, IFormattable, IComparable
	{
		/// <summary>
		/// Gets user role tree root
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>user role tree root</returns>
		TreeNode<TUserRoleEnum> GetUserRoleTreeRoot(Context context);
	}
}
