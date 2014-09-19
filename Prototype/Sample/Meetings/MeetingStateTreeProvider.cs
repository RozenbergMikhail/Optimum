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
	/// Implements meeting state tree provider
	/// </summary>
	public class MeetingStateTreeProvider : IEntityStateTreeProvider<MeetingState>
	{
		/// <summary>
		/// Gets entity state tree root
		/// </summary>
		/// <returns>entity state tree root</returns>
		public TreeNode<MeetingState> GetEntityStateTreeRoot()
		{
			var root = new TreeNode<MeetingState>(
				MeetingState.All,
				new List<TreeNode<MeetingState>>()
				{
					new TreeNode<MeetingState>(MeetingState.Active),
					new TreeNode<MeetingState>(MeetingState.Cancelled),
					new TreeNode<MeetingState>(MeetingState.Rescheduled),
					new TreeNode<MeetingState>(MeetingState.Past)
				});

			return root;
		}
	}
}
