//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Platform.Development;
using Platform.ServiceResolvers;
using Platform.System;

namespace Platform.Contexts
{
	/// <summary>
	/// Contains context data
	/// </summary>
	public class Context
	{
		private readonly Dictionary<string, object> items;

		private readonly IServiceResolver<IUTCTimeProvider> UTCTimeProviderResolver;
		private readonly IServiceResolver<ILocalTimeOffsetProvider> localTimeOffsetProviderResolver;
		private readonly IServiceResolver<IUICultureProvider> UICultureProviderResolver;

		protected Object syncRoot = new Object();

		/// <summary>
		/// Creates new instance of <see cref="Context"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public Context(ContextInitData initData)
		{
			if (initData == null)
				throw new MemoryPointerIsNullException("initData");

			initData.ValidatePropertiesNotNull();

			this.UTCTimeProviderResolver = initData.UTCTimeProviderResolver;
			this.localTimeOffsetProviderResolver = initData.LocalTimeOffsetProviderResolver;
			this.UICultureProviderResolver = initData.UICultureProviderResolver;

			this.items = new Dictionary<string, object>();
		}

		/// <summary>
		/// Adds new custom item into the context
		/// </summary>
		/// <param name="key">item key</param>
		/// <param name="item">item</param>
		public void AddCustomItem(string key, object item)
		{
			items.Add(key, item);
		}

		/// <summary>
		/// Gets custom item by key
		/// </summary>
		/// <param name="key">item key</param>
		/// <returns>item</returns>
		public object GetCustomItem(string key)
		{
			object result;
			items.TryGetValue(key, out result);
			return result;
		}
		
		/// <summary>
		/// Gets current UTC time
		/// </summary>
		/// <returns>current UTC time</returns>
		public DateTime GetCurrentTimeUTC()
		{
			return this.UTCTimeProviderResolver.GetService(this).GetCurrentUTCTime();
		}

		/// <summary>
		/// Gets local time offset
		/// </summary>
		/// <returns>local time offset</returns>
		public TimeSpan GetLocalTimeOffset()
		{
			return this.localTimeOffsetProviderResolver.GetService(this).GetCurrentLocalTimeOffset();
		}

		/// <summary>
		/// Converts specified UTC time to local time
		/// </summary>
		/// <param name="utcTime">UTC time</param>
		/// <returns>local time</returns>
		public DateTime ConvertUTCToLocalTime(DateTime utcTime)
		{
			Debug.Assert(utcTime.Kind == DateTimeKind.Utc, "utcTime.Kind == DateTimeKind.Utc");

			return utcTime + this.GetLocalTimeOffset();
		}

		/// <summary>
		/// Converts specified local time to UTC time
		/// </summary>
		/// <param name="localTime">local time</param>
		/// <returns>UTC time</returns>
		public DateTime ConvertLocalTimeToUTC(DateTime localTime)
		{
			Debug.Assert(localTime.Kind == DateTimeKind.Utc, "localTime.Kind == DateTimeKind.Utc"); // not a mistake!

			return localTime - this.GetLocalTimeOffset();
		}

		/// <summary>
		/// Gets current local time
		/// </summary>
		/// <returns>current local time</returns>
		public DateTime GetCurrentTimeLocal()
		{
			return this.ConvertUTCToLocalTime(this.GetCurrentTimeUTC());
		}

		/// <summary>
		/// Gets current UI culture
		/// </summary>
		/// <returns>current UI culture</returns>
		public CultureInfo GetCurrentUICulture()
		{
			return this.UICultureProviderResolver.GetService(this).GetCurrentUICulture();
		}

		/// <summary>
		/// Gets context snapshot
		/// </summary>
		/// <returns>context snapshot</returns>
		public virtual ContextSnapshot GetSnapshot()
		{
			var snapshotInitData = new ContextSnapshotInitData()
			{
				UTCTime = this.GetCurrentTimeUTC(),
				LocalTimeOffset = this.GetLocalTimeOffset(),
				UICulture = this.GetCurrentUICulture(),
			};

			return new ContextSnapshot(snapshotInitData);
		}
	}
}
