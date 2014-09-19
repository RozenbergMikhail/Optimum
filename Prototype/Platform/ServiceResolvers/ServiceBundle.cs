//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Platform.Development;
using Platform.Contexts;

namespace Platform.ServiceResolvers
{
	/// <summary>
	/// Defines a bundle of services
	/// </summary>
	public sealed class ServiceBundle
	{
		private readonly Dictionary<Type, IServiceResolver> interfaceServiceResolverMappings;

		/// <summary>
		/// Creates new <see cref="ServiceBundle"/> instance
		/// </summary>
		public ServiceBundle()
		{
			this.interfaceServiceResolverMappings = new Dictionary<Type, IServiceResolver>();
		}

		#region IServiceBundle members

		/// <summary>
		/// Gets service resolver
		/// </summary>
		/// <typeparam name="T">interface type</typeparam>
		/// <returns>servide resolver instance</returns>
		public IServiceResolver<T> GetServiceResolver<T>() where T : class
		{
			IServiceResolver serviceResolver;
			if (this.interfaceServiceResolverMappings.TryGetValue(typeof(T), out serviceResolver))
			{
				return (IServiceResolver<T>)serviceResolver;
			}

			throw new ServiceIsMissingException(typeof(T));
		}

		/// <summary>
		/// Gets context provider
		/// </summary>
		/// <typeparam name="T">interface type</typeparam>
		/// <returns>context provider instance</returns>
		public T GetContextProvider<T>() where T : class, IContextProvider
		{
			return GetServiceInternal<T>(null);
		}

		/// <summary>
		/// Gets the service instance of the specified interface type using the provided context information
		/// </summary>
		/// <typeparam name="T">interface type</typeparam>
		/// <param name="context">system context</param>
		/// <returns>service instance</returns>
		public T GetService<T>(Context context) where T : class
		{
			Debug.Assert(context != null, "context != null");

			return GetServiceInternal<T>(context);
		}

		/// <summary>
		/// Adds service resolvers from another bundle
		/// </summary>    
		/// <param name="bundle">service bundle</param>
		public void AddServiceResolversFromAnotherBundle(ServiceBundle bundle)
		{
			Debug.Assert(bundle != null, "bundle != null");

			foreach (var interfaceServiceMapping in bundle.interfaceServiceResolverMappings)
			{
				this.interfaceServiceResolverMappings.Add(interfaceServiceMapping.Key, interfaceServiceMapping.Value);
			}
		}

		/// <summary>
		/// Adds new service resolver into the bundle
		/// </summary>
		/// <typeparam name="T">interface type</typeparam>
		/// <param name="serviceResolver">service resolver</param>
		public void AddServiceResolver<T>(IServiceResolver<T> serviceResolver) where T : class
		{
			this.interfaceServiceResolverMappings.Add(typeof(T), serviceResolver);
		}

		/// <summary>
		/// Removes service resolver from the bundle
		/// </summary>
		/// <param name="interfaceType">interface type</param>
		public void RemoveServiceResolver(Type interfaceType)
		{
			Debug.Assert(interfaceType != null, "interfaceType != null");

			this.interfaceServiceResolverMappings.Remove(interfaceType);
		}

		#endregion

		private T GetServiceInternal<T>(Context context) where T : class
		{
			IServiceResolver serviceResolver;
			if (this.interfaceServiceResolverMappings.TryGetValue(typeof(T), out serviceResolver))
			{
				var result = ((IServiceResolver<T>)serviceResolver).GetService(context);
				if (result != null)
				{
					return result;
				}
			}

			throw new ServiceIsMissingException(typeof(T));
		}
	}
}
