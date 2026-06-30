using System;
using System.ComponentModel.DataAnnotations.Schema;
using SmartTaskManagement.Domain.Enums;

namespace SmartTaskManagement.Domain.Entities
{
	public class TaskItem
	{

        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Priority Priority { get; set; }  //= "Low";

        public TaskItemStatus Status { get; set; }  //= "To Do";

        public DateTime DueDate { get; set; }

        public int AssignedToUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(AssignedToUserId))]
        public User? User { get; set; }


    }
}

