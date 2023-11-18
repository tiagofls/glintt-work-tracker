namespace GlinttWorkTracker.Console
{
    using GlinttWorkTracker.Console.Tests.Features;
    using GlinttWorkTracker.Domain;
    using GlinttWorkTracker.Domain.Models;
    using GlinttWorkTracker.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using System;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Feature1.RunTest();
            Console.WriteLine("\n------------------------------------\n");
            await Feature2.RunTest();
            Console.WriteLine("\n------------------------------------\n");
            await Feature3.RunTest();
            Console.WriteLine("\n------------------------------------\n");
            await Feature4.RunTest();
            Console.WriteLine("\n------------------------------------\n");
            await Feature5.RunTest();
        }
    }
}