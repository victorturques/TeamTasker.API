using TeamTasker.API.Entities;

namespace TeamTasker.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user); 
        Task DeleteAsync(User user);
        Task<bool> UserExistsAsync(int id); 
    }
}