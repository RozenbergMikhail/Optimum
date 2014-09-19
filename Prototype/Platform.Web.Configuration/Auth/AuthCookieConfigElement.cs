//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Configuration;

namespace Platform.Web.Configuration.Auth
{
	/// <summary>
	/// Contains auth cookie configuration data
	/// </summary>
	public class AuthCookieConfigElement : ConfigurationElement
	{
		/// <summary>
		/// Defines name of the "Name" configuration property
		/// </summary>
		public const string NamePropertyName = "Name";

		/// <summary>
		/// Gets name
		/// </summary>
		[ConfigurationProperty(NamePropertyName, IsRequired = true)]
		public string Name
		{
			get
			{
				return (string)base[NamePropertyName];
			}
		}

		internal bool Initialized
		{
			get
			{
				return !String.IsNullOrEmpty(this.Name);
			}
		}
	}
}
