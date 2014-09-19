//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Info;

namespace Platform.Logging
{
	/// <summary>
	/// Declares log provider
	/// </summary>
	public interface ILogProvider
	{
		/// <summary>
		/// Gets description of the item
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="info">information to log</param>
		void LogInformation(Context context, InfoEntity info);
	}
}
