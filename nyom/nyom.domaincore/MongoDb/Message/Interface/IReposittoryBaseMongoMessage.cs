﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace nyom.domain.core.MongoDb.Message.Interface
{
	public interface IReposittoryBaseMongoMessage<TEntity,in TKey> where TEntity : IEntity<TKey>
	{
		TEntity Get(Guid id);
		TEntity Find(Expression<Func<TEntity, bool>> predicate);
		ICollection<TEntity> All();
		ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
		TEntity Save(TEntity entity);
		void Delete(Guid id);
		void Delete(TEntity entity);
		TEntity Update(TEntity entity);
	}
}