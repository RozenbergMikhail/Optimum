//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Abstractions;
using Platform.Auth;
using Platform.Contexts;

namespace Sample.Auth
{
	/// <summary>
	/// Implements sample user role tree provider
	/// </summary>
	public class SampleUserRoleTreeProvider : IUserRoleTreeProvider<SampleUserRole>
	{
		/// <summary>
		/// Gets user role tree root
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>user role tree root</returns>
		public TreeNode<SampleUserRole> GetUserRoleTreeRoot(Context context)
		{
			var root = new TreeNode<SampleUserRole>(SampleUserRole.All,
				new List<TreeNode<SampleUserRole>>()
				{
					new TreeNode<SampleUserRole>(SampleUserRole.Authenticated,
						new List<TreeNode<SampleUserRole>>() 
						{
							new TreeNode<SampleUserRole>(SampleUserRole.User),
							new TreeNode<SampleUserRole>(SampleUserRole.Admin),
						}),
					new TreeNode<SampleUserRole>(SampleUserRole.Anonymous),
				});

			return root;
		}
	}
}
