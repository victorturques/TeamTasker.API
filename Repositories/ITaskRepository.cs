using TeamTasker.API.Entities;

namespace TeamTasker.API.Repositories
{
    public interface ITaskRepository
    {
        
        Task<List<JobTask>> GetAllAsync();
        Task<JobTask?> GetByIdAsync(int id);
        Task AddAsync(JobTask task);
        Task UpdateAsync(JobTask task);
        Task DeleteAsync(JobTask task);
    }
}