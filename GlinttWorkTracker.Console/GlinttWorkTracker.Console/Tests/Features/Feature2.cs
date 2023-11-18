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
    public class Feature2
    {
        public static async Task RunTest()
        {
            Console.WriteLine("Feature2: getting all works from database\n\nRunning test now...\n\n");
            try
            {
                using (var uow = new UnitOfWork())
                {
                    IEnumerable<Work> l = await uow.WorkRepository.GetAll();
                    Console.WriteLine("Quantity of regists: " + l.Count());
                    foreach (var work in l)
                    {
                        Console.WriteLine($"\nWork Id: {work.Id}");
                        Console.WriteLine($"GlinttApp: {work.GlinttApp}");
                        Console.WriteLine($"Description: {work.Description}");
                        Console.WriteLine($"Epic: {work.Epic}");
                        Console.WriteLine($"IdIssue: {work.IdIssue}");
                        Console.WriteLine($"Date: {work.Date}\n");
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
