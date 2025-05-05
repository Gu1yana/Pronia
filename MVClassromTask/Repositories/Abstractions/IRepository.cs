using MVClassromTask.Models.Common;

namespace MVClassromTask.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity    
    {
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
