using Core.Entities;

namespace Core.Interfaces.Repository
{
    public interface IGenericRepository<T> where T  : BaseEntity 
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}