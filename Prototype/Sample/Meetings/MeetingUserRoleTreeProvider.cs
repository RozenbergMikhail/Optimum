//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Abstractions;
using Platform.Entities;

namespace Sample.Meetings
{
	/// <summary>
	/// Implements meeting user role tree provider
	/// </summary>
	public class MeetingUserRoleTreeProvider : IEntityUserRoleTreeProvider<MeetingUserRole>
	{
		/// <summary>
		/// Gets entity user role tree root
		/// </summary>
		/// <returns>entity user role tree root</returns>
		public TreeNode<MeetingUserRole> GetEntityUserRoleTreeRoot()
		{
			var root = new TreeNode<MeetingUserRole>(
				MeetingUserRole.All,
				new List<TreeNode<MeetingUserRole>>()
				{
					new TreeNode<MeetingUserRole>(
						MeetingUserRole.RelatedToMeeting,
						new List<TreeNode<MeetingUserRole>>() 
						{
							new TreeNode<MeetingUserRole>(MeetingUserRole.Organizer),
							new TreeNode<MeetingUserRole>(MeetingUserRole.Attendee),
						}),
					new TreeNode<MeetingUserRole>(MeetingUserRole.NotRelatedToMeeting),
				});

			return root;
		}
	}
}
