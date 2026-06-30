using System;
using SmartTaskManagement.Domain.Entities;

namespace SmartTaskManagement.Application.Interface
{
	public interface IUserRepository
	{
		Task<User?> GetByEmailAsync(string email);//This method is used to find a user in the database using their email address.

        Task AddAsync(User user); // "Asynchronously add a new user record to the database."

        Task SaveChangesAsync(); // Actually save the user to SQL Server.

    }
}

