using GlinttWorkTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlinttWorkTracker.Console.Tests.Features
{
    using GlinttWorkTracker.Domain.Models;
    using System;
    public class Feature3
    {
        public static async Task RunTest()
        {
            Console.WriteLine("Feature3: updating an existing work\n\nRunning test now...\n\n");
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var w = new Work
                    {
                        Id = 8,
                        GlinttApp = "EPR-MOBILE",
                        Description = "Adição de um campo novo, no ecrã de sinistros",
                        Epic = "GX-198763",
                        IdIssue = 1,
                        Date = DateTime.Now
                    };
                    bool l = await uow.WorkRepository.Update_(w);
                    if (l)
                    {
                        Console.WriteLine("Work has been updated successfully.");
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
