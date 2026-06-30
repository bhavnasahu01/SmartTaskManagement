
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskManagement.Application.DTOs;
using SmartTaskManagement.Application.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartTaskManagement.API.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterRequestDto request)
        {
            await _authService.RegisterAsync(request);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequestDto request)
        {
            var result =
                await _authService.LoginAsync(request);

            return Ok(result);
        }

    }
}

