using GlinttWorkTracker.Domain.Models;
using GlinttWorkTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Console.Tests.Features
{
    using System;
    public class Feature5
    {
        public static async Task RunTest()
        {
            Console.WriteLine("Feature4: finding an existing work by id\n\nRunning test now...\n\n");
            try
            {
                using (var uow = new UnitOfWork())
                {
                    Work work = await uow.WorkRepository.FindById("8");
                    if (work != null)
                    {
                        Console.WriteLine($"\nWork Id: {work.Id}");
                        Console.WriteLine($"GlinttApp: {work.GlinttApp}");
                        Console.WriteLine($"Description: {work.Description}");
                        Console.WriteLine($"Epic: {work.Epic}");
                        Console.WriteLine($"IdIssue: {work.IdIssue}");
                        Console.WriteLine($"Date: {work.Date}\n");
                    }
                    else
                    {
                        Console.WriteLine("The work do not exists.");
                    }
                }
                Console.WriteLine("\n\nTest done successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nTEST FAILED\n    |||\n    |||\n    vvv\n" + ex.ToString());
            }
        }
    }
}
