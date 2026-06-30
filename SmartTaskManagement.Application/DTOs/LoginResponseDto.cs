using System;
namespace SmartTaskManagement.Application.DTOs
{
  //Step 3 after login they give respone as token ,email and role
	public class LoginResponseDto
	{
        public string Token { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}

