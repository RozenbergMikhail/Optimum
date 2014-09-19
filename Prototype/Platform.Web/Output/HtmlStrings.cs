//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Web;

namespace Platform.Web.Output
{
	/// <summary>
	/// A helper class for working with HTML strings
	/// </summary>
	public static class HtmlStrings
	{
		/// <summary>
		/// Gets encoded string
		/// </summary>
		/// <param name="rawString">raw string</param>
		/// <returns>encoded string</returns>
		public static string Encode(string rawString)
		{
			return rawString != null ? HttpUtility.HtmlEncode(rawString) : null;
		}

		/// <summary>
		/// Gets decoded string
		/// </summary>
		/// <param name="rawString">raw string</param>
		/// <returns>decoded string</returns>
		public static string Decode(string rawString)
		{
			return rawString != null ? HttpUtility.HtmlDecode(rawString) : null;
		}
	}
}