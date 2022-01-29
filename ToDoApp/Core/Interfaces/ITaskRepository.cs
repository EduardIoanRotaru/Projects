using Core.Entities;
using Core.Interfaces.Repository;

namespace Core.Interfaces
{
    public interface ITaskRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
         Task<T> GetTasksWithComments(int id);
         Task<IEnumerable<T>> GetTaskByProjectIdAndPK(int projectId, int[] taskId);
    }
}