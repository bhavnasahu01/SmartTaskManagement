using System;
using SmartTaskManagement.Application.DTOs;

namespace SmartTaskManagement.Application.Interface
{
	public interface IAuthService
	{
		Task RegisterAsync(RegisterRequestDto request);

        //DTO is used to transfer only required data between client and server while hiding internal entity structure.

        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
	}
}

