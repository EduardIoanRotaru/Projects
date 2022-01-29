using Core.Entities;

namespace Core.Interfaces
{
    public interface IUpcomingTasksRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllOrderedByDate();
        Task<IReadOnlyList<T>> GetAllOrderedByLabel();
        Task<IReadOnlyList<T>> GetAllOrderedByDateAndNotcompleted();
    }
}