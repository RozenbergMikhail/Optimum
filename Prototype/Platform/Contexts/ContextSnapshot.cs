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
	/// Contains context snapshot data
	/// </summary>
	public class ContextSnapshot
	{
		/// <summary>
		/// Creates new instance of <see cref="ContextSnapshot"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public ContextSnapshot(ContextSnapshotInitData initData)
		{
			if (initData == null)
				throw new MemoryPointerIsNullException("initData");

			initData.ValidatePropertiesNotNull();

			this.UTCTime = initData.UTCTime;
			this.LocalTimeOffset = initData.LocalTimeOffset;
			this.UICulture = initData.UICulture;
		}

		/// <summary>
		/// Gets UTC time
		/// </summary>
		public DateTime UTCTime
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets local time offset
		/// </summary>
		public TimeSpan LocalTimeOffset
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets UI culture
		/// </summary>
		public CultureInfo UICulture
		{
			get;
			private set;
		}
	}
}
