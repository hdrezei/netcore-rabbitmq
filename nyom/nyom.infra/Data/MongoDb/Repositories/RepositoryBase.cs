﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using nyom.domain.core.MongoDb.IEntity;
using nyom.domain.core.MongoDb.Repository.Interface;
using nyom.infra.Data.MongoDb.Context;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.infra.Data.MongoDb.Repositories
{
	public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
		where TEntity : IEntity
	{
		protected readonly MongoMessageContext<TEntity> _context;

		protected RepositoryBase(IOptions<MongoDbSettings> settings, string collectionName)
		{
			_context = new MongoMessageContext<TEntity>(settings, collectionName);
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}


		public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Collection
				.AsQueryable()
				.Where(predicate.Compile())
				.ToList();
		}


		public async Task<TEntity> GetOneAsync(TEntity context)
		{
			return await _context.Collection.Find(new BsonDocument("_id", context.Id)).FirstOrDefaultAsync();
		}

		public async Task<TEntity> GetOneAsync(string id)
		{
			return await _context.Collection.Find(f => f.Id.Equals(id)).FirstOrDefaultAsync();
		}

		public async Task<TEntity> SaveOneAsync(TEntity Context)
		{
			await _context.Collection.InsertOneAsync(Context);
			return Context;
		}

		public async Task<TEntity> RemoveOneAsync(TEntity context)
		{
			return await _context.Collection.FindOneAndDeleteAsync(context.Id);
		}

		public async Task<TEntity> RemoveOneAsync(string id)
		{
			return await _context.Collection.FindOneAndDeleteAsync(id);
		}
	}
}