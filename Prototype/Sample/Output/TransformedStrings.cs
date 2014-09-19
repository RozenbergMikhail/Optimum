//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Sample.Output
{
	/// <summary>
	/// A helper class for working with sample string transformations
	/// </summary>
	public static class TransformedStrings
	{
		/// <summary>
		/// Gets transformed string
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="rawString">raw string</param>
		/// <returns>transformed string</returns>
		public static string Transform(Context context, string rawString)
		{
			return rawString != null ? rawString.Replace('s', '$') : null;
		}
	}
}