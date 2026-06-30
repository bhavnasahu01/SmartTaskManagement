using System;
namespace SmartTaskManagement.Application.DTOs
{
    // step 2
    // If user is registeer then user try to login 
    public class LoginRequestDto
	{
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

