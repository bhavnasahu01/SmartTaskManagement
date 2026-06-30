using System;
using SmartTaskManagement.Domain.Enums;
namespace SmartTaskManagement.Application.Interface
{
	public interface IPriorityService
	{
        Priority CalculatePriority( string title, string description,DateTime dueDate);
    }
}

