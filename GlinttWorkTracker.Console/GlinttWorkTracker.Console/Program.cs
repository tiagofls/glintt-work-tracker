namespace GlinttWorkTracker.Console
{
    using GlinttWorkTracker.Domain;
    using GlinttWorkTracker.Domain.Models;
    using GlinttWorkTracker.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using System;
    public class Program
    {
        static async Task Main(string[] args)
        {
            //var x = new Work { 
            //    GlinttApp = "EPR-MOBILE",
            //    Date = DateTime.Now, 
            //    Description = "",
            //    Epic = "GX-182736",
            //    IdIssue = 1,
            //    Id = 1,
            //};
            using (var uow = new UnitOfWork())
            {
                //uow.WorkRepository.Create(x);
                IEnumerable<Issue> l = await uow.WorkRepository.GetAllIssues();
                foreach (var issue in l)
                {
                    Console.WriteLine($"Issue Id: {issue.Id}, Type: {issue.Type}");
                }
            }
        }
    }
}