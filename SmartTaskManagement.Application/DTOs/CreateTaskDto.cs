using System;
namespace SmartTaskManagement.Application.DTOs
{
	public class CreateTaskDto
	{
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int AssignedUserId { get; set; }
    }
}

