using System;
using SmartTaskManagement.Domain.Entities;

namespace SmartTaskManagement.Application.Interface
{
	public interface ITaskRepository
	{
        Task AddAsync(TaskItem task);

        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task<TaskItem?> GetByIdAsync(int id);

        Task UpdateAsync(TaskItem task);

        Task DeleteAsync(TaskItem task);

        Task SaveChangesAsync();
    }
}

