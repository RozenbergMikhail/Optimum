//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.Development
{
	/// <summary>
	/// Defines source code not implemented exception
	/// </summary>
	public class SourceCodeNotImplementedException : Exception
	{
		/// <summary>
		/// Creates new instance of <see cref="SourceCodeNotImplementedException"/>
		/// </summary>
		public SourceCodeNotImplementedException()
		{
			this.Info = "Source code hasn't been implemented yet";
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