using System;
namespace SmartTaskManagement.Application.DTOs
{

    // Step1.First user Register.
    //Step 2 login
	public class RegisterRequestDto
	{
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}

