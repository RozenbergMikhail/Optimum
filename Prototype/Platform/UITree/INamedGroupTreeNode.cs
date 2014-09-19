//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.UITree
{
	/// <summary>
	/// Declares interface of named group tree node
	/// </summary>
	public interface INamedGroupTreeNode : IUITreeNode
	{
		/// <summary>
		/// Gets group name
		/// </summary>
		/// <returns>group name</returns>
		string GetGroupName();
	}
}
