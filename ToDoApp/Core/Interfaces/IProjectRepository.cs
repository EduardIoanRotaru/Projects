using Core.Entities;
using Core.Interfaces.Repository;

namespace Core.Interfaces
{
    public interface IProjectRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetProjectWithTasks(int id);
    }
}