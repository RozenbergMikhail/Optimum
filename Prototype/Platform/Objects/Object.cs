//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using Platform.Contexts;

namespace Platform.Objects
{
	/// <summary>
	/// Defines base class for objects
	/// </summary>
	public abstract class Object
	{
		/// <summary>
		/// Gets string description of an object with regard to the specified context
		/// </summary>
		/// <param name="context">context</param>
		/// <returns>string representation</returns>
		public abstract string GetObjectDescription(Context context);
	}
}
