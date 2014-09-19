//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Entities;

namespace Sample.YetAnotherTypes
{
	/// <summary>
	/// Contains yet another sample type data
	/// </summary>
	public class YetAnotherType : Entity
	{
		/// <summary>
		/// Creates new instance of <see cref="YetAnotherType"/>
		/// </summary>
		/// <param name="name">name</param>
		public YetAnotherType(string name)
		{
			this.Name = name;
		}

		/// <summary>
		/// Gets name
		/// </summary>
		public string Name
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
			return string.Format("Name={0};", this.Name);
		}
	}
}
