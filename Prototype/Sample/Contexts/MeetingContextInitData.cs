//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Development;
using Platform.ServiceResolvers;
using Sample.Meetings;

namespace Sample.Contexts
{
	/// <summary>
	/// Contains meeting context initialization data
	/// </summary>
	public class MeetingContextInitData : UserContextInitData
	{
		/// <summary>
		/// Creates new instance of <see cref="MeetingContextInitData"/>
		/// </summary>
		/// <param name="contextInitData">context init data</param>
		public MeetingContextInitData(ContextInitData contextInitData)
			: base(contextInitData)
		{
		}

		/// <summary>
		/// Gets or sets current meeting id
		/// </summary>
		public int CurrentMeetingId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets meeting provider resolver
		/// </summary>
		public IServiceResolver<IMeetingProvider> MeetingProviderResolver
		{
			get;
			set;
		}

		/// <summary>
		/// Validates initialization data
		/// </summary>
		public override void ValidatePropertiesNotNull()
		{
			base.ValidatePropertiesNotNull();

			if (this.MeetingProviderResolver == null)
				throw new MemoryPointerIsNullException("MeetingProviderResolver");
		}
	}
}
