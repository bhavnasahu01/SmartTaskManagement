using System;
using Microsoft.Extensions.Configuration;

namespace SmartTaskManagement.Infrastructure.Services
{
	public class AzureOpenAIPriorityService
	{
        private readonly IConfiguration _configuration;

        public AzureOpenAIPriorityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void TestConnection()
        {
            var endpoint = _configuration["AzureOpenAI:Endpoint"];
            var apiKey = _configuration["AzureOpenAI:ApiKey"];
            var deployment = _configuration["AzureOpenAI:DeploymentName"];

            Console.WriteLine(endpoint);
            Console.WriteLine(apiKey);
            Console.WriteLine(deployment);
        }
    }
}

