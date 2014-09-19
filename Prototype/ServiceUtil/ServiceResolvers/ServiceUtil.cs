//
// Copyright (c) 2014. All rights reserved.
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace ClientApp.ServiceResolvers
{
	/// <summary>
	/// Defines helper class for fetching services from the application service bundle
	/// </summary>
	internal static class ServiceUtil
	{
		private const string SectionGroupName = "SampleGroup";
		private const string PlatformFullSectionName = SectionGroupName + "/Platform";
		private const string PlatformWebFullSectionName = SectionGroupName + "/PlatformWeb";
		private const string SampleFullSectionName = SectionGroupName + "/Sample";

		private static readonly ClientApp.Bundles.Services Instance = new ClientApp.Bundles.Services(PlatformFullSectionName, PlatformWebFullSectionName, SampleFullSectionName);

		/// <summary>
		/// Gets the instance of context provider
		/// </summary>
		/// <returns>context provider instance</returns>
		public static T GetContextProvider<T>() where T : class, IContextProvider
		{
			return Instance.Bundle.GetContextProvider<T>();
		}

		/// <summary>
		/// Gets the service instance of the specified interface type
		/// </summary>
		/// <param name="context">context</param>
		/// <typeparam name="T">interface type</typeparam>
		/// <returns>service instance</returns>
		public static T GetService<T>(Context context) where T : class
		{
			return Instance.Bundle.GetService<T>(context);
		}
	}
}
