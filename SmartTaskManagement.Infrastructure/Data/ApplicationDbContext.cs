using System;
using Microsoft.EntityFrameworkCore;
using SmartTaskManagement.Domain.Entities;

namespace SmartTaskManagement.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{

		}

		public DbSet<User> Users => Set<User>();

        // public DbSet<TaskItem> TaskItems => Set<TaskItem>();

        public DbSet<TaskItem> TaskItems { get; set; }

	

    }
}

