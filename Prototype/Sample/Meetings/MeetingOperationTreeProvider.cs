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
	/// Implements meeting operation tree provider
	/// </summary>
	public class MeetingOperationTreeProvider: IEntityOperationTreeProvider<MeetingOperation>
	{
		/// <summary>
		/// Gets entity operation tree root
		/// </summary>
		/// <returns>entity operation tree root</returns>
		public TreeNode<MeetingOperation> GetEntityOperationTreeRoot()
		{
			var root = new TreeNode<MeetingOperation>(
				MeetingOperation.All,
				new List<TreeNode<MeetingOperation>>()
				{
					new TreeNode<MeetingOperation>(MeetingOperation.Create),
					new TreeNode<MeetingOperation>(MeetingOperation.Edit),
					new TreeNode<MeetingOperation>(MeetingOperation.Cancel),
					new TreeNode<MeetingOperation>(MeetingOperation.Accept),
					new TreeNode<MeetingOperation>(MeetingOperation.Reject),
					new TreeNode<MeetingOperation>(MeetingOperation.Reschedule),
					new TreeNode<MeetingOperation>(MeetingOperation.ProposeNewTime),
				});

			return root;
		}
	}
}
