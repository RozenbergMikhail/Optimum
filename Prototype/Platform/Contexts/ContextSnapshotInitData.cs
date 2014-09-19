//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Globalization;
using Platform.Development;

namespace Platform.Contexts
{
	/// <summary>
	/// Contains context snapshot initialization data
	/// </summary>
	public class ContextSnapshotInitData
	{
		/// <summary>
		/// Gets or sets UTC time
		/// </summary>
		public DateTime UTCTime
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets local time offset
		/// </summary>
		public TimeSpan LocalTimeOffset
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets UI culture
		/// </summary>
		public CultureInfo UICulture
		{
			get;
			set;
		}

		/// <summary>
		/// Validates initialization data
		/// </summary>
		public virtual void ValidatePropertiesNotNull()
		{
			if (this.UICulture == null)
				throw new MemoryPointerIsNullException("UICulture");
		}
	}
}
