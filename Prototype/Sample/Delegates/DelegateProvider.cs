//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;

namespace Sample.Delegates
{
	/// <summary>
	/// Implements delegate provider
	/// </summary>
	public class DelegateProvider : IDelegateProvider
	{
		private readonly Dictionary<int, Delegate> delegates;

		/// <summary>
		/// Creates new instance of <see cref="DelegateProvider"/>
		/// </summary>
		public DelegateProvider()
		{
			this.delegates = LoadDelegates();
		}

		/// <summary>
		/// Gets delegate
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="delegateId">delegate identifier</param>
		/// <returns>delegate</returns>
		public Delegate GetDelegate(Context context, int delegateId)
		{
			return this.delegates[delegateId];
		}

		private Dictionary<int, Delegate> LoadDelegates()
		{
			// TODO: load surname (and possibly other user data) from some storage

			var result = new Dictionary<int, Delegate>();

			result.Add(1, new Delegate(new DelegateInitData()
			{
				Id = 1,
				UserId = 100,
				Surname = "TEST SURNAME",
			}));
			result.Add(2, new Delegate(new DelegateInitData() {
				Id = 2,
				UserId = 101, 
				Surname = "ANOTHER SURNAME",
			}));

			return result;
		}
	}
}
