using CarsCRUD.Entity;

namespace CarsCRUD.InterfacesForRepositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(string id);
    }
}