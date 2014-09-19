//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.System;
using Platform.Development;
using Platform.ServiceResolvers;

namespace Platform.Contexts
{
	/// <summary>
	/// Contains context initialization data
	/// </summary>
	public class ContextInitData
	{
		/// <summary>
		/// Creates new instance of <see cref="ContextInitData"/>
		/// </summary>
		public ContextInitData()
		{
		}

		/// <summary>
		/// Creates new instance of <see cref="ContextInitData"/>
		/// </summary>
		/// <param name="other">other context init data</param>
		public ContextInitData(ContextInitData other)
		{
			if (other == null)
				throw new MemoryPointerIsNullException("other");

			this.UTCTimeProviderResolver = other.UTCTimeProviderResolver;
			this.LocalTimeOffsetProviderResolver = other.LocalTimeOffsetProviderResolver;
			this.UICultureProviderResolver = other.UICultureProviderResolver;
		}

		/// <summary>
		/// Gets or sets UTC time provider resolver
		/// </summary>
		public IServiceResolver<IUTCTimeProvider> UTCTimeProviderResolver
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets local time offset provider resolver
		/// </summary>
		public IServiceResolver<ILocalTimeOffsetProvider> LocalTimeOffsetProviderResolver
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets UI culture provider resolver
		/// </summary>
		public IServiceResolver<IUICultureProvider> UICultureProviderResolver
		{
			get;
			set;
		}

		/// <summary>
		/// Validates initialization data
		/// </summary>
		public virtual void ValidatePropertiesNotNull()
		{
			if (this.UTCTimeProviderResolver == null)
				throw new MemoryPointerIsNullException("UTCTimeProviderResolver");

			if (this.LocalTimeOffsetProviderResolver == null)
				throw new MemoryPointerIsNullException("LocalTimeOffsetProviderResolver");

			if (this.UICultureProviderResolver == null)
				throw new MemoryPointerIsNullException("UICultureProviderResolver");
		}
	}
}
