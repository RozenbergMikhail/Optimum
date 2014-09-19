//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;
using Platform.Development;
using Platform.System;
using Platform.Contexts;
using Platform.ServiceResolvers;
using Sample.Delegates;
using Sample.Meetings;

namespace ClientApp.Bundles
{
	/// <summary>
	/// Defines service bundle of the application
	/// </summary>
	public class Services : ServiceBundleWrapper
	{
		/// <summary>
		/// Creates new instance of <see cref="Services"/>
		/// </summary>
		/// <param name="platformFullSectionName">full section name of platform section</param>
		/// <param name="platformWebFullSectionName">full section name of platform web section</param>
		/// <param name="sampleFullSectionName">full section name of sample web section</param>
		public Services(string platformFullSectionName, string platformWebFullSectionName, string sampleFullSectionName)
		{
			if (platformFullSectionName == null)
				throw new MemoryPointerIsNullException("platformFullSectionName");

			if (platformWebFullSectionName == null)
				throw new MemoryPointerIsNullException("platformWebFullSectionName");

			if (sampleFullSectionName == null)
				throw new MemoryPointerIsNullException("sampleFullSectionName");

			this.Bundle.AddServiceResolversFromAnotherBundle(new Platform.Bundles.System.Services(platformFullSectionName).Bundle);
			this.Bundle.AddServiceResolversFromAnotherBundle(new Platform.Web.Bundles.Auth.Services(platformWebFullSectionName).Bundle);
			this.Bundle.AddServiceResolversFromAnotherBundle(new Sample.Bundles.Auth.Services(this.Bundle.GetServiceResolver<IUTCTimeProvider>()).Bundle);
			this.Bundle.AddServiceResolversFromAnotherBundle(new Sample.Bundles.Delegates.Services().Bundle);
			this.Bundle.AddServiceResolversFromAnotherBundle(new Sample.Bundles.SampleTypes.Services(sampleFullSectionName).Bundle);
			this.Bundle.AddServiceResolversFromAnotherBundle(new Sample.Bundles.AnotherTypes.Services(sampleFullSectionName).Bundle);
			this.Bundle.AddServiceResolversFromAnotherBundle(new Sample.Bundles.YetAnotherTypes.Services(sampleFullSectionName).Bundle);
			this.Bundle.AddServiceResolversFromAnotherBundle(new Sample.Bundles.Meetings.Services(this.Bundle.GetServiceResolver<IDelegateProvider>()).Bundle);

			var contextInitData = new ContextInitData()
			{
				UTCTimeProviderResolver = this.Bundle.GetServiceResolver<IUTCTimeProvider>(),
				LocalTimeOffsetProviderResolver = this.Bundle.GetServiceResolver<ILocalTimeOffsetProvider>(),
				UICultureProviderResolver = this.Bundle.GetServiceResolver<IUICultureProvider>(),
			};

			var contextServices = new Sample.Bundles.Contexts.Services(contextInitData,
				this.Bundle.GetServiceResolver<IUserDataProvider>(),
				this.Bundle.GetServiceResolver<IMeetingProvider>());
			this.Bundle.AddServiceResolversFromAnotherBundle(contextServices.Bundle);
		}
	}
}
