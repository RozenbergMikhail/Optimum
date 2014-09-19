//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using Platform.Development;
using Platform.Contexts;
using Platform.Info;

namespace Platform.Entities
{
	/// <summary>
	/// Defines base class for all exceptions of all entities
	/// </summary>
	public abstract class EntityException : Exception
	{
		protected Entity entity;
		protected InfoEntity info;

		/// <summary>
		/// Gets entity type
		/// </summary>
		/// <returns>entity type</returns>
		public abstract Type GetEntityType();

		/// <summary>
		/// Gets information entity type
		/// </summary>
		/// <returns>information entity type</returns>
		public abstract Type GetInfoEntityType();

		/// <summary>
		/// Gets entity
		/// </summary>
		/// <returns>entity</returns>
		public Entity GetEntity()
		{
			return entity;
		}

		/// <summary>
		/// Gets information object
		/// </summary>
		/// <returns>information object</returns>
		public InfoEntity GetInfo()
		{
			return info;
		}

		/// <summary>
		/// Gets entity object
		/// </summary>
		/// <returns>entity</returns>
		public TEntity GetEntity<TEntity>() where TEntity : Entity
		{
			return (TEntity)entity;
		}

		/// <summary>
		/// Gets information
		/// </summary>
		/// <returns>information</returns>
		public TInfoEntity GetInfo<TInfoEntity>() where TInfoEntity : InfoEntity
		{
			return (TInfoEntity)info;
		}
	}

	/// <summary>
	/// Defines base class for all exceptions of the specified entity
	/// </summary>
	/// <typeparam name="TEntity">entity type</typeparam>
	public abstract class EntityException<TEntity> : EntityException
		where TEntity : Entity
	{
		/// <summary>
		/// Creates new instance of <see cref="EntityException{TEntity}"/>
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="entity">entity</param>
		protected EntityException(Context context, TEntity entity)
		{
			if (context == null)
				throw new MemoryPointerIsNullException("context");

			if (entity == null)
				throw new MemoryPointerIsNullException("entity");

			this.Entity = entity;
			this.ContextSnapshot = context.GetSnapshot();
		}

		/// <summary>
		/// Gets context snapshot
		/// </summary>
		public ContextSnapshot ContextSnapshot
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets entity
		/// </summary>
		public TEntity Entity
		{
			get
			{
				return (TEntity)entity;
			}
			private set
			{
				entity = value;
			}
		}

		/// <summary>
		/// Gets entity type
		/// </summary>
		/// <returns>entity type</returns>
		public sealed override Type GetEntityType()
		{
			return typeof(TEntity);
		}
	}

	/// <summary>
	/// Defines entity exception class
	/// </summary>
	/// <typeparam name="TEntity">entity type</typeparam>
	/// <typeparam name="TInfoEntity">information entity type</typeparam>
	public class EntityException<TEntity, TInfoEntity> : EntityException<TEntity>
		where TEntity : Entity
		where TInfoEntity : InfoEntity
	{
		/// <summary>
		/// Creates new instance of <see cref="EntityException{TEntity,TInfoEntity}"/>
		/// </summary>
		/// <param name="context">context</param>
		/// <param name="entity">entity</param>
		/// <param name="info">information entity</param>
		public EntityException(Context context, TEntity entity, TInfoEntity info)
			: base(context, entity)
		{
			if (info == null)
				throw new MemoryPointerIsNullException("info");

			this.Info = info;
		}

		/// <summary>
		/// Gets information
		/// </summary>
		public TInfoEntity Info
		{
			get
			{
				return (TInfoEntity)info;
			}
			private set
			{
				info = value;
			}
		}

		/// <summary>
		/// Gets information entity type
		/// </summary>
		/// <returns>information entity type</returns>
		public sealed override Type GetInfoEntityType()
		{
			return typeof(TInfoEntity);
		}
	}
}