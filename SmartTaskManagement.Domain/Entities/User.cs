using System;
namespace SmartTaskManagement.Domain.Entities
{
	public class User
	{

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();


    }
}

