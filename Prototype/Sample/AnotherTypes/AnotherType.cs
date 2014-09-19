//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;
using Platform.Entities;

namespace Sample.AnotherTypes
{
	/// <summary>
	/// Contains another sample type data
	/// </summary>
	public class AnotherType : Entity
	{
		/// <summary>
		/// Creates new instance of <see cref="AnotherType"/>
		/// </summary>
		/// <param name="name">name</param>
		/// <param name="description">description</param>
		public AnotherType(string name, string description)
		{
			this.Name = name;
			this.Description = description;
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
		/// Gets description
		/// </summary>
		public string Description
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
			return string.Format("Name='{0}'; Description='{1}'", this.Name, this.Description);
		}
	}
}
