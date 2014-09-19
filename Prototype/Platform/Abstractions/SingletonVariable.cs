//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Development;

namespace Platform.Abstractions
{
	/// <summary>
	/// Represents singleton variable
	/// </summary>
	/// <typeparam name="T">variable type</typeparam>
	public sealed class SingletonVariable<T> where T : class
	{
		private T variable;
		private readonly Func<T> variableInitFunc;
		private volatile bool isValueInitialized;
		private object syncRoot;

		/// <summary>
		/// Creates new <see cref="SingletonVariable{T}"/> instance
		/// </summary>
		/// <param name="variableInitFunc">variable initialization function</param>
		public SingletonVariable(Func<T> variableInitFunc)
		{
			if (variableInitFunc == null)
				throw new MemoryPointerIsNullException("variableInitFunc");

			this.variableInitFunc = variableInitFunc;
			this.isValueInitialized = false;
			this.syncRoot = new object();
		}

		/// <summary>
		/// Gets variable value
		/// </summary>
		public T Value
		{
			get
			{
				if (!this.isValueInitialized)
				{
					lock (this.syncRoot)
					{
						if (!this.isValueInitialized)
						{
							this.variable = variableInitFunc();
							this.isValueInitialized = true;
						}
					}
				}

				return this.variable;
			}
		}
	}
}
