//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Development;
using Platform.Entities;

namespace Sample.Delegates
{
	/// <summary>
	/// Contains delegate data
	/// </summary>
	public class Delegate : Entity
	{
		/// <summary>
		/// Creates new instance of <see cref="Delegate"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public Delegate(DelegateInitData initData)
		{
			if (initData == null)
				throw new MemoryPointerIsNullException("initData");

			this.Id = initData.Id;
			this.UserId = initData.UserId;
			this.Surname = initData.Surname;
		}

		/// <summary>
		/// Gets delegate identifier
		/// </summary>
		public int Id
		{
			get;
			private set;
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
		/// Gets string description of an object with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>string representation</returns>
		public override string GetObjectDescription(Context context)
		{
			return Surname + "(" + Id + "," + UserId + ")";
		}
	}
}