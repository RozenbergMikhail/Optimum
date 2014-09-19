//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Sample.Auth
{
	/// <summary>
	/// Declares sample user token factory methods
	/// </summary>
	public interface ISampleUserTokenFactory
	{
		/// <summary>
		/// Creates sample user token
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="userId">user identifier</param>
		/// <returns>sample user token</returns>
		SampleUserToken CreateUserToken(Context context, int userId);
	}
}
