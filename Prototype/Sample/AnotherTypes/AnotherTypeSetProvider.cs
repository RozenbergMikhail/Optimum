//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;

namespace Sample.AnotherTypes
{
	/// <summary>
	/// Implements another sample type set provider
	/// </summary>
	public class AnotherTypeSetProvider : IAnotherTypeSetProvider
	{
		private readonly Dictionary<string, AnotherType> anotherTypes;

		/// <summary>
		/// Creates new instance of <see cref="AnotherTypeSetProvider"/>
		/// </summary>
		public AnotherTypeSetProvider()
		{
			this.anotherTypes = LoadAnotherTypes();
		}

		/// <summary>
		/// Gets another sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>another sample type instances</returns>
		public IEnumerable<AnotherType> GetAnotherTypeInstances(Context context)
		{
			return this.anotherTypes.Values;
		}

		/// <summary>
		/// Gets another sample type instance by name
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="name">name</param>
		/// <returns>another sample type instance</returns>
		public AnotherType GetAnotherTypeInstanceByName(Context context, string name)
		{
			AnotherType result;
			this.anotherTypes.TryGetValue(name, out result);
			return result;
		}

		private static Dictionary<string, AnotherType> LoadAnotherTypes()
		{
			var result = new Dictionary<string, AnotherType>();
			result.Add("If", new AnotherType("If", "1"));
			result.Add("I", new AnotherType("I", "2"));
			result.Add("Will", new AnotherType("Will", "3"));
			result.Add("Recharge", new AnotherType("Recharge", "4"));
			result.Add("The", new AnotherType("The", "5"));
			result.Add("Batteries", new AnotherType("Batteries", "6"));
			result.Add("This", new AnotherType("This", "7"));
			result.Add("Music", new AnotherType("Music", "8"));
			result.Add("Last", new AnotherType("Last", "9"));
			result.Add("Forever", new AnotherType("Forever", "10"));
			result.Add("Here", new AnotherType("Here", "11"));
			result.Add("There", new AnotherType("There", "12"));
			return result;
		}
	}
}
