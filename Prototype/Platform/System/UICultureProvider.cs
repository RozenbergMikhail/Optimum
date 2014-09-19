//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Globalization;
using System.Threading;

namespace Platform.System
{
	/// <summary>
	/// Implements UI culture provider
	/// </summary>
	public class UICultureProvider : IUICultureProvider
	{
		/// <summary>
		/// Gets current UI culture
		/// </summary>
		/// <returns>UI culture info</returns>
		public CultureInfo GetCurrentUICulture()
		{
			return Thread.CurrentThread.CurrentUICulture;
		}
	}
}
