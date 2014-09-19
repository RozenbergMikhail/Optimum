//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.Development
{
	/// <summary>
	/// Defines memory pointer is null exception
	/// </summary>
	public class MemoryPointerIsNullException : Exception
	{
		/// <summary>
		/// Creates new instance of <see cref="MemoryPointerIsNullException"/>
		/// </summary>
		/// <param name="pointerVariableName">pointer variable name</param>
		public MemoryPointerIsNullException(string pointerVariableName)
		{
			this.PointerVariableName = pointerVariableName;
			this.Info = "Unexpected null value of memory pointer: '{0}'";
		}

		/// <summary>
		/// Gets pointer variable name
		/// </summary>
		public string PointerVariableName
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets information message
		/// </summary>
		public string Info
		{
			get;
			private set;
		}
	}
}