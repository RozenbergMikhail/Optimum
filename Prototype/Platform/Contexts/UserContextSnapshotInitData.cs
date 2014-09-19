//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;
using Platform.Development;

namespace Platform.Contexts
{
	/// <summary>
	/// Contains user context snapshot initialization data
	/// </summary>
	public class UserContextSnapshotInitData : ContextSnapshotInitData
	{
		/// <summary>
		/// Gets or sets UTC time
		/// </summary>
		public UserData UserData
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

			if (this.UserData == null)
				throw new MemoryPointerIsNullException("UserData");
		}
	}
}
