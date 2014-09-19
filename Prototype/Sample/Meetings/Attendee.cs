//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//


using Platform.Contexts;
using Platform.Development;
using Platform.Entities;
using Sample.Delegates;

namespace Sample.Meetings
{
	/// <summary>
	/// Contains meeting attendee data
	/// </summary>
	public class Attendee : Entity
	{
		private readonly IDelegateProvider delegateProvider;

		/// <summary>
		/// Creates new instance of <see cref="Attendee"/>
		/// </summary>
		/// <param name="initData">initialization data</param>
		public Attendee(AttendeeInitData initData)
		{
			if (initData == null)
				throw new MemoryPointerIsNullException("initData");

			this.Id = initData.Id;
			this.DelegateId = initData.DelegateId;
			this.State = initData.State;
			this.delegateProvider = initData.DelegateProvider;
		}

		/// <summary>
		/// Gets attendee identifier
		/// </summary>
		public int Id
		{
			get; 
			private set;
		}

		/// <summary>
		/// Gets delegate identifier
		/// </summary>
		public int DelegateId
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets attendee delegate
		/// </summary>
		/// <param name="context">context</param>
		public Delegate GetDelegate(Context context)
		{
			return this.delegateProvider.GetDelegate(context, this.DelegateId);
		}

		/// <summary>
		/// Gets state
		/// </summary>
		public AttendeeState State
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
			return string.Format("Id={0}; DelegateId={1}; State={2}", this.Id, this.DelegateId, this.State);
		}
	}
}
