//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Auth;

namespace Sample.Auth
{
	/// <summary>
	/// Contains sample user data
	/// </summary>
	public sealed class SampleUserData : UserData
	{
		/// <summary>
		/// Creates new instance of <see cref="SampleUserData"/>
		/// </summary>
		/// <param name="userId">user identifier</param>
		/// <param name="surname">surname</param>
		public SampleUserData(int userId, string surname)
		{
			this.UserId = userId;
			this.Surname = surname;
		}

		/// <summary>
		/// Gets user identifier
		/// </summary>
		public int UserId
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets surname
		/// </summary>
		public string Surname
		{
			get;
			private set;
		}

		/// <summary>
		/// Returns string representation of the instance
		/// </summary>
		/// <returns>string representation of the instance</returns>
		public override string ToString()
		{
			return Surname + "(" + UserId + ")";
		}
	}
}