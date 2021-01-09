using MarsRoverProject.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRoverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Register Dependency Injection 
            var serviceProvider = new ServiceCollection().AddSingleton<IRoverService, RoverService>()
           .AddSingleton<RoverConsole>()
           .BuildServiceProvider();

            //do the actual work here
            var _roverservice = serviceProvider.GetService<RoverConsole>();
           _roverservice.Run();

        }
    }
}
