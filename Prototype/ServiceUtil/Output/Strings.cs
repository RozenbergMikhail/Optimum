//
// Copyright (c) 2014. All rights reserved.
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Web.Output;
using Sample.Output;

namespace ClientApp.Output
{
	/// <summary>
	/// Helper class for working with strings in the application
	/// </summary>
	internal static class Strings
	{
		/// <summary>
		/// Gets transformed string with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="rawString">raw string</param>
		/// <returns>transformed string</returns>
		public static string GetTransformedString(Context context, string rawString)
		{
			return TransformedStrings.Transform(context, rawString);
		}

		/// <summary>
		/// Gets HTML-encoded string
		/// </summary>
		/// <param name="rawString">raw string</param>
		/// <returns>HTML-encoded string</returns>
		public static string GetHtmlEncodedString(string rawString)
		{
			return HtmlStrings.Encode(rawString);
		}

		/// <summary>
		/// Gets HTML-encoded transformed string with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="rawString">raw string</param>
		/// <returns>HTML-encoded string</returns>
		public static string GetHtmlEncodedTransformedString(Context context, string rawString)
		{
			return GetHtmlEncodedString(GetTransformedString(context, rawString));
		}
	}
}
