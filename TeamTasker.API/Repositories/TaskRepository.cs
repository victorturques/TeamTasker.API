using Microsoft.EntityFrameworkCore;
using TeamTasker.API.Data;
using TeamTasker.API.Entities;

namespace TeamTasker.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobTask>> GetAllAsync()
        {
            return await _context.JobTasks
                .AsNoTracking()
                .Include(t => t.User) // O Join fica aqui agora
                .ToListAsync();
        }

        public async Task<JobTask?> GetByIdAsync(int id)
        {
            return await _context.JobTasks
                .Include(t => t.User) 
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(JobTask task)
        {
            _context.JobTasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobTask task)
        {
            _context.JobTasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(JobTask task)
        {
            _context.JobTasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}