//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.Web.Auth
{
	/// <summary>
	/// Contains authentication cookie properties
	/// </summary>
	public class AuthCookieProperties
	{
		/// <summary>
		/// Creates new instance of <see cref="AuthCookieProperties"/>
		/// </summary>
		/// <param name="name">name</param>
		public AuthCookieProperties(string name)
		{
			this.Name = name;
		}

		/// <summary>
		/// Gets name
		/// </summary>
		public string Name
		{
			get; 
			private set;
		}

		/// <summary>
		/// Returns string representation of the instance
		/// </summary>
		/// <returns>string representation of the instance</returns>
		public override string ToString()
		{
			return this.Name;
		}
	}
}
