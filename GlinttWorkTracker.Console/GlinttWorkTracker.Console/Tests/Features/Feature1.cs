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
    public class Feature1
    {
        public static async Task RunTest()
        {
            Console.WriteLine("Feature1: add a work to database\n\nRunning test now...\n\n");
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var w = new Work
                    {
                        Id = 0,
                        GlinttApp = "ERP-MOBILE",
                        Description = "Adição de um campo novo",
                        Epic = "GX-198763",
                        IdIssue = 1,
                        Date = DateTime.Now
                    };
                    bool l = await uow.WorkRepository.AddWork(w);
                    if (l)
                    {
                        Console.WriteLine("A new work was added to database.");
                    }
                    else
                    {
                        Console.WriteLine("The work already exists.");
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
