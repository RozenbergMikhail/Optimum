//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Platform.ServiceResolvers
{
	/// <summary>
	/// Declares public interface of a service resolver
	/// </summary>
	public interface IServiceResolver
	{
	}

	/// <summary>
	/// Declares public interface of a service resolver
	/// </summary>
	/// <typeparam name="T">service interface type</typeparam>
	public interface IServiceResolver<out T> : IServiceResolver where T : class
	{
		/// <summary>
		/// Gets the service instance using the provided context information
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>service instance</returns>
		T GetService(Context context);
	}
}
