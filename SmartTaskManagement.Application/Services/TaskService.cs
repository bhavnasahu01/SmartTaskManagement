using System;
using SmartTaskManagement.Application.DTOs;
using SmartTaskManagement.Application.Interface;
using SmartTaskManagement.Domain.Entities;
using SmartTaskManagement.Domain.Enums;

namespace SmartTaskManagement.Application.Services
{
	public class TaskService : ITaskService
	{
        private readonly ITaskRepository _taskRepository;
        private readonly IPriorityService _priorityService;

        public TaskService(ITaskRepository taskRepository,IPriorityService priorityService)
        {
            _taskRepository = taskRepository;
            _priorityService = priorityService;
        }

        public async Task CreateTaskAsync(CreateTaskDto request)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,

                AssignedToUserId = request.AssignedUserId,

                Status = TaskItemStatus.ToDo,

                // Priority = "Medium", // now we are replacing here 
                Priority = _priorityService.CalculatePriority(
                request.Title,
                request.Description,
                request.DueDate),

                CreatedDate = DateTime.UtcNow
            };

            await _taskRepository.AddAsync(task);

            await _taskRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();

            return tasks.Select(task => new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
                Priority = task.Priority.ToString(),
                DueDate = task.DueDate,
                AssignedUserName = task.User?.Name


            });
        }

        public async Task<TaskResponseDto?> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                return null;

            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status.ToString(),
                Priority = task.Priority.ToString(),
                DueDate = task.DueDate,
                AssignedUserName = task.User?.Name
            };
        }

        public async Task UpdateTaskAsync(int id, UpdateTaskDto request)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                throw new Exception("Task not found");

            task.Title = request.Title;
            task.Description = request.Description;
            task.Status = request.Status;
            task.DueDate = request.DueDate;

            await _taskRepository.UpdateAsync(task);

            await _taskRepository.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                throw new Exception("Task not found");

            await _taskRepository.DeleteAsync(task);

            await _taskRepository.SaveChangesAsync();
        }
    }
}

