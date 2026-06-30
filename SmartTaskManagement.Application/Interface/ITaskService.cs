using System;
using SmartTaskManagement.Application.DTOs;

namespace SmartTaskManagement.Application.Interface
{
	public interface ITaskService
	{
        Task CreateTaskAsync(CreateTaskDto request);

        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync();

        Task<TaskResponseDto?> GetTaskByIdAsync(int id);

        Task UpdateTaskAsync(int id, UpdateTaskDto request);

        Task DeleteTaskAsync(int id);
    }
}

