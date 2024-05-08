using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Delivery.Api.Entity;

namespace Delivery.Api.Repository;

public class GenericRepository<T> where T : BaseEntity<string>
{
    private readonly IMongoCollection<T> _collection;

    public GenericRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<T>(typeof(T).Name);
    }

    public async Task InsertAsync(T document)
    {
        await _collection.InsertOneAsync(document);
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<List<T>> FilterAsync(Expression<Func<T, bool>> filterExpression)
    {
        return await _collection.Find(filterExpression).ToListAsync();
    }

    public async Task<bool> UpdateAsync(string id, T document)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);

        var result = await _collection.ReplaceOneAsync(filter, document);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq(e => e.Id, id);

        var result = await _collection.DeleteOneAsync(filter);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}