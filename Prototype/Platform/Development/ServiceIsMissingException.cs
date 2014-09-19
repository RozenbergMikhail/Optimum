//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;

namespace Platform.Development
{
	/// <summary>
	/// Defines service is missing exception
	/// </summary>
	public class ServiceIsMissingException : Exception
	{
		/// <summary>
		/// Creates new instance of <see cref="ServiceIsMissingException"/>
		/// </summary>
		/// <param name="interfaceType">interface type</param>
		public ServiceIsMissingException(Type interfaceType)
		{
			this.InterfaceType = interfaceType;
			this.Info = "Service is missing: {0}";
		}

		/// <summary>
		/// Gets interface type
		/// </summary>
		public Type InterfaceType
		{
			get;
			private set;
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