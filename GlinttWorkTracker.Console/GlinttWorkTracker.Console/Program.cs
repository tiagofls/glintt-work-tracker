using GlinttWorkTracker.Domain;
using GlinttWorkTracker.Domain.Models;
using GlinttWorkTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GlinttWorkTracker.Console
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //var x = new Work { Description = "Teste", GlinttApp = "Teste", Epic = "Teste", Date = DateTime.Now };
            //using (var uow = new UnitOfWork())
            //{
            //    await uow.WorkRepository.UpsertAsync(x);
            //}

            using (var context = new GlinttWorkTrackerDbContext())
            {

            }

        }
    }
}