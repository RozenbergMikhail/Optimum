//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.System
{
	/// <summary>
	/// Implements console provider
	/// </summary>
	public class ConsoleProvider : IConsoleProvider
	{
		/// <summary>
		/// Writes line of text onto current system console
		/// </summary>
		/// <param name="format">format</param>
		/// <param name="args">arguments</param>
		public void WriteLine(string format, params object[] args)
		{
			Console.WriteLine(format, args);
		}

		/// <summary>
		/// Reads key from system console
		/// </summary>
		/// <returns>console key info</returns>
		public ConsoleKeyInfo ReadKey()
		{
			return Console.ReadKey();
		}
	}
}
