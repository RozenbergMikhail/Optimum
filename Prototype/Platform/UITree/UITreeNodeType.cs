//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.UITree
{
	/// <summary>
	/// Enumerates possible UI tree node types
	/// </summary>
	public enum UITreeNodeType
	{
		/// <summary>
		/// Entity
		/// </summary>
		Entity = 1,

		/// <summary>
		/// Group of elements
		/// </summary>
		Group = 2,

		/// <summary>
		/// Named group of elements
		/// </summary>
		NamedGroup = 3,

		/// <summary>
		/// Separator
		/// </summary>
		Separator = 4
	}
}