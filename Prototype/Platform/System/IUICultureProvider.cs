//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Globalization;

namespace Platform.System
{
	/// <summary>
	/// Declares UI culture provider
	/// </summary>
	public interface IUICultureProvider
	{
		/// <summary>
		/// Gets current UI culture
		/// </summary>
		/// <returns>UI culture info</returns>
		CultureInfo GetCurrentUICulture();
	}
}
