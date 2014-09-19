//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.System
{
	/// <summary>
	/// Declares console provider
	/// </summary>
	public interface IConsoleProvider
	{
		/// <summary>
		/// Writes line of text onto system console
		/// </summary>
		/// <param name="format">format</param>
		/// <param name="args">arguments</param>
		void WriteLine(string format, params object[] args);

		/// <summary>
		/// Reads key from system console
		/// </summary>
		/// <returns>console key info</returns>
		ConsoleKeyInfo ReadKey();
	}
}
