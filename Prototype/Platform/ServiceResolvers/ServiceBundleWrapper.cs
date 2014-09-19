//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

namespace Platform.ServiceResolvers
{
	/// <summary>
	/// Defines wrapper class for a service bundle
	/// </summary>
	public abstract class ServiceBundleWrapper
	{
		private readonly ServiceBundle wrappedBundle;

		/// <summary>
		/// Creates new <see cref="ServiceBundleWrapper"/> instance
		/// </summary>
		protected ServiceBundleWrapper()
		{
			this.wrappedBundle = new ServiceBundle();
		}

		/// <summary>
		/// Gets wrapped bundle
		/// </summary>
		public ServiceBundle Bundle
		{
			get
			{
				return this.wrappedBundle;
			}
		}
	}
}
