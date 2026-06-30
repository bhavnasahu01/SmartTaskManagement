using System;
using SmartTaskManagement.Application.Interface;
using SmartTaskManagement.Domain.Enums;

namespace SmartTaskManagement.Infrastructure.Services
{
	public class PriorityService : IPriorityService
	{
        //now we are replacing the method
        //public string CalculatePriority(string title,string description, DateTime dueDate)
        //{
        //    return "Medium";
        //}



        //public Priority CalculatePriority(string title, string description,DateTime dueDate)
        //{
        //    title = title.ToLower();
        //    description = description.ToLower();

        //    // Critical
        //    if (title.Contains("production") ||
        //        title.Contains("server down") ||
        //        title.Contains("security"))
        //    {
        //        return Priority.Critical;
        //    }

        //    // High
        //    if (dueDate.Date <= DateTime.Today.AddDays(1))
        //    {
        //        return Priority.High;
        //    }

        //    if (title.Contains("bug"))
        //    {
        //        return Priority.High;
        //    }

        //    // Low
        //    if (title.Contains("documentation"))
        //    {
        //        return Priority.Low;
        //    }

        //    // Default
        //    return Priority.Medium;
        //}




        public Priority CalculatePriority(string title,string description, DateTime dueDate)
        {
            string text =(title + " " + description).ToLower();

            // Critical
            if (text.Contains("production") ||
                text.Contains("server down") ||
                text.Contains("security") ||
                text.Contains("payment failure"))
            {
                return Priority.Critical;
            }

            // High
            if (text.Contains("login bug") ||
                text.Contains("bug"))
            {
                return Priority.High;
            }

            // Due Today or Tomorrow
            if (dueDate.Date <= DateTime.Today.AddDays(1))
            {
                return Priority.High;
            }

            // Low
            if (text.Contains("documentation"))
            {
                return Priority.Low;
            }

            // Default
            return Priority.Medium;
        }

    }
}





