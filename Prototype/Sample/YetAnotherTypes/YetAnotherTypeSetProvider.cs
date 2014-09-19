//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System.Collections.Generic;
using Platform.Contexts;

namespace Sample.YetAnotherTypes
{
	/// <summary>
	/// Implements yet another sample type set provider
	/// </summary>
	public class YetAnotherTypeSetProvider : IYetAnotherTypeSetProvider
	{
		private readonly Dictionary<string, YetAnotherType> yetAnotherTypes;

		/// <summary>
		/// Creates new instance of <see cref="YetAnotherTypeSetProvider"/>
		/// </summary>
		public YetAnotherTypeSetProvider()
		{
			this.yetAnotherTypes = LoadYetAnotherTypes();
		}

		/// <summary>
		/// Gets yet another sample type instances
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>yet another sample type instances</returns>
		public IEnumerable<YetAnotherType> GetYetAnotherTypeInstances(Context context)
		{
			return this.yetAnotherTypes.Values;
		}

		/// <summary>
		/// Gets yet another sample type instance by name
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="name">name</param>
		/// <returns>yet another sample type instance</returns>
		public YetAnotherType GetYetAnotherTypeInstanceByName(Context context, string name)
		{
			YetAnotherType result;
			this.yetAnotherTypes.TryGetValue(name, out result);
			return result;
		}

		private static Dictionary<string, YetAnotherType> LoadYetAnotherTypes()
		{
			var result = new Dictionary<string, YetAnotherType>();
			result.Add("Red", new YetAnotherType("Red"));
			result.Add("Orange", new YetAnotherType("Orange"));
			result.Add("Yellow", new YetAnotherType("Yellow"));
			result.Add("Green", new YetAnotherType("Green"));
			result.Add("Blue", new YetAnotherType("Blue"));
			result.Add("Purple", new YetAnotherType("Purple"));
			return result;
		}
	}
}
