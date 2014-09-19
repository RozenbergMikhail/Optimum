//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Diagnostics;
using Platform.Contexts;

namespace Platform.ServiceResolvers
{
	/// <summary>
	/// Defines default service resolver wrapping single service
	/// </summary>
	/// <typeparam name="T">service interface type</typeparam>
	public class ServiceResolver<T> : IServiceResolver<T> where T : class
	{
		private readonly T serviceInstance;

		/// <summary>
		/// Creates new <see cref="ServiceResolver{T}"/> instance
		/// </summary>
		/// <param name="serviceInstance">service instance</param>
		public ServiceResolver(T serviceInstance)
		{
			Debug.Assert(serviceInstance != null, "serviceInstance != null");

			this.serviceInstance = serviceInstance;
		}

		/// <summary>
		/// Gets the service instance using the provided context information
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>service instance</returns>
		public T GetService(Context context)
		{
			return this.serviceInstance;
		}

		/// <summary>
		/// Gets the service instance
		/// </summary>
		public T Service
		{
			get
			{
				return this.serviceInstance;
			}
		}
	}
}
