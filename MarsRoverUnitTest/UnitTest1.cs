using MarsRoverProject.Models;
using MarsRoverProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRoverUnitTest
{
    [TestClass]
    public class UnitTest1
    {        
        internal static int RoverNumber = 1;

        [TestMethod]
        public void TestMethod1()
        {
            var serviceProvider = new ServiceCollection().AddSingleton<IRoverService, RoverService>()
             .AddSingleton<RoverConsole>()
             .BuildServiceProvider();
         
            var _service = serviceProvider.GetService<IRoverService>();            

            RoverModel[] RoverModelList = new RoverModel[RoverNumber];

            string AreaValuesLine = "5 5";

            string[] SplittedAreaValues = AreaValuesLine.Split(' ');
            var Width = Convert.ToInt32(SplittedAreaValues[0]);
            var Height = Convert.ToInt32(SplittedAreaValues[1]);

            for (int i = 0; i < RoverNumber; i++)
            {
                string RoverValuesLine = "1 2 N";
                string[] SplittedRoverValues = RoverValuesLine.Split(' ');

                var PositionX = Convert.ToInt32(SplittedRoverValues[0]);
                var PositionY = Convert.ToInt32(SplittedRoverValues[1]);
                var Direction = SplittedRoverValues[2];

                string RoverPathCommandLine = "LMLMLMLMM";

                RoverModelList[i] = _service.CalculateRoverCoordinates(Width, Height, RoverPathCommandLine, PositionX, PositionY, Direction);
            }

            Console.WriteLine("Output:");

            for (int i = 0; i < RoverNumber; i++)
            {
                Console.WriteLine(RoverModelList[i].PositionX + " " + RoverModelList[i].PositionY + " " + RoverModelList[i].Direction);

            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var serviceProvider = new ServiceCollection().AddSingleton<IRoverService, RoverService>()
               .AddSingleton<RoverConsole>()
               .BuildServiceProvider();

           
            var _service = serviceProvider.GetService<IRoverService>();

            RoverModel[] RoverModelList = new RoverModel[RoverNumber];
          
            string AreaValuesLine = "5 5";

            string[] SplittedAreaValues = AreaValuesLine.Split(' ');
            var Width = Convert.ToInt32(SplittedAreaValues[0]);
            var Height = Convert.ToInt32(SplittedAreaValues[1]);

            for (int i = 0; i < RoverNumber; i++)
            {
                string RoverValuesLine = "3 3 E";
                string[] SplittedRoverValues = RoverValuesLine.Split(' ');

                var PositionX = Convert.ToInt32(SplittedRoverValues[0]);
                var PositionY = Convert.ToInt32(SplittedRoverValues[1]);
                var Direction = SplittedRoverValues[2];

                string RoverPathCommandLine = "MMRMMRMRRM";

                RoverModelList[i] = _service.CalculateRoverCoordinates(Width, Height, RoverPathCommandLine, PositionX, PositionY, Direction);
            }

            Console.WriteLine("Output:");

            for (int i = 0; i < RoverNumber; i++)
            {
                Console.WriteLine(RoverModelList[i].PositionX + " " + RoverModelList[i].PositionY + " " + RoverModelList[i].Direction);

            }
        }
    }
}
