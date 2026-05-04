using TeamTasker.API.Entities;

namespace TeamTasker.API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);
        
        Task<User?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        
        Task AddAsync(User user);
        
        Task UpdateAsync(User user); 
        
        Task DeleteAsync(User user);
        
        Task<bool> UserExistsAsync(int id); 
    }
}