using System;
using SmartTaskManagement.Application.DTOs;
using SmartTaskManagement.Application.Interface;
using SmartTaskManagement.Domain.Entities;
using BCrypt.Net;

namespace SmartTaskManagement.Application.Services
{


    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IUserRepository userRepository,IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role,
                CreatedDate = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

           
        }


        public async Task<LoginResponseDto>LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(request.Password,user.PasswordHash);

            if (!isValid)
            {
                throw new Exception("Invalid email or password");
            }

            var token =_jwtTokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role
            };
        }

       
    }
}

