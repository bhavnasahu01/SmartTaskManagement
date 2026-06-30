using System;
using SmartTaskManagement.Domain.Enums;
namespace SmartTaskManagement.Application.DTOs
{
	public class UpdateTaskDto
	{
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskItemStatus Status { get; set; }

        public DateTime DueDate { get; set; }
    }
}

