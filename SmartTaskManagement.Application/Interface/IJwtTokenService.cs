using System;
using SmartTaskManagement.Domain.Entities;

namespace SmartTaskManagement.Application.Interface
{
	public interface IJwtTokenService
	{
        string GenerateToken(User user);

    }
}

