using System;
using Microsoft.EntityFrameworkCore;
using SmartTaskManagement.Application.Interface;
using SmartTaskManagement.Domain.Entities;
using SmartTaskManagement.Infrastructure.Data;

namespace SmartTaskManagement.Infrastructure.Repositories
{
	public class TaskRepository : ITaskRepository
	{

        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskItem task)
        {
            await _context.TaskItems.AddAsync(task);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
           // return await _context.TaskItems.ToListAsync();
           return await _context.TaskItems
        .Include(x => x.User)
        .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems
        .Include(x => x.User)  // Without Include(), EF Core only loads the TaskItem table.With Include(), EF Core also loads the related User.
        .FirstOrDefaultAsync(x => x.Id == id);
            // .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(TaskItem task)
        {
            _context.TaskItems.Update(task);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TaskItem task)
        {
            _context.TaskItems.Remove(task);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

