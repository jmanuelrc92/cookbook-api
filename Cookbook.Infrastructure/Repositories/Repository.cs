﻿using Cookbook.Application.Repositories;
using Cookbook.Domain.Extensions;
using Cookbook.Domain.Models.Configuration;
using Cookbook.Domain.Models.Persistance;
using MongoDB.Driver;

namespace Recipes.Infrastructure.Repositories;
public class Repository<TDocument> : IRepository<TDocument>
	where TDocument : IDocument
{
	private readonly IMongoCollection<TDocument>	_collection;
	
	public Repository(MongoDbSettings mongoDbSettings)
	{
		var database = new MongoClient(mongoDbSettings.ConnectionString).GetDatabase(mongoDbSettings.DatabaseName);
		_collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
	}
	
	private protected string GetCollectionName(Type documentType)
	{
		return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
			typeof(BsonCollectionAttribute),
			true)
			.FirstOrDefault())?.CollectionName;
	}
	
	public virtual IQueryable<TDocument> AsQueryable()
	{
		return _collection.AsQueryable();
	}

	public void DeleteById(string id)
	{
		var objectId = new ObjectId(id);
		var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
		_collection.FindOneAndDelete(filter);
	}

	public Task DeleteByIdAsync(string id)
	{
		return Task.Run(() =>
		{
			var objectId = new ObjectId(id);
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
			_collection.FindOneAndDeleteAsync(filter);
		});
	}

	public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
	{
		_collection.DeleteMany(filterExpression);
	}

	public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
	{
		return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
	}

	public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
	{
		_collection.FindOneAndDelete(filterExpression);
	}

	public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
	{
		return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
	}

	public IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
	{
		return _collection.Find(filterExpression).ToEnumerable();
	}

	public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression, Expression<Func<TDocument, TProjected>> projectExpression)
	{
		return _collection.Find(filterExpression).Project(projectExpression).ToEnumerable();
	}

	public virtual TDocument FindById(string id)
	{
		var objectId = new ObjectId(id);
		var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
		return _collection.Find(filter).SingleOrDefault();
	}

	public virtual Task<TDocument> FindByIdAsync(string id)
	{
		return Task.Run(() =>
		{
			var objectId = new ObjectId(id);
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
			return _collection.Find(filter).SingleOrDefaultAsync();
		});
	}

	public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
	{
		return _collection.Find(filterExpression).FirstOrDefault();
	}

	public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
	{
		return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
	}

	public void InsertMany(ICollection<TDocument> documents)
	{
		_collection.InsertMany(documents);
	}

	public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
	{
		await _collection.InsertManyAsync(documents);
	}

	public virtual void InsertOne(TDocument document)
	{
		_collection.InsertOne(document);
	}

	public virtual Task InsertOneAsync(TDocument document)
	{
		return Task.Run(() => _collection.InsertOneAsync(document));
	}

	public void ReplaceOne(TDocument document)
	{
		var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
		_collection.FindOneAndReplace(filter, document);
	}

	public virtual async Task ReplaceOneAsync(TDocument document)
	{
		var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
		await _collection.FindOneAndReplaceAsync(filter, document);
	}
}
