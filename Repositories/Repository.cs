using CarsCRUD.Entity;
using CarsCRUD.InterfacesForRepositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarsCRUD.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public Repository(IMongoCollection<TEntity> collection)
        {
            _collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }
        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                throw new ArgumentException("Invalid ObjectId format", nameof(id));
            }

            var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _collection.FindAsync(_ => true);
            return entities.ToEnumerable().AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var filter = Builders<TEntity>.Filter.Eq(doc => doc.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
        }
    }
}