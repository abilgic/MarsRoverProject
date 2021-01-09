using MarsRoverProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProject.Services
{
    public class RoverConsole
    {
        private const int RoverNumber = 2;
        private readonly IRoverService _service;
        public RoverConsole(IRoverService service)
        {
            _service = service;
        }

        public void Run()
        {
            RoverModel[] RoverModelList = new RoverModel[RoverNumber];
            try
            {
                Console.WriteLine("Test Input:");
                string AreaValuesLine = Console.ReadLine();

                string[] SplittedAreaValues = AreaValuesLine.Split(' ');
                var Width = Convert.ToInt32(SplittedAreaValues[0]);
                var Height = Convert.ToInt32(SplittedAreaValues[1]);

                for (int i = 0; i < RoverNumber; i++)
                {
                    string RoverValuesLine = "";
                    RoverValuesLine = Console.ReadLine();
                    string[] SplittedRoverValues = RoverValuesLine.Split(' ');

                    var PositionX = Convert.ToInt32(SplittedRoverValues[0]);
                    var PositionY = Convert.ToInt32(SplittedRoverValues[1]);
                    var Direction = SplittedRoverValues[2];

                    string RoverPathCommandLine = "";

                    RoverPathCommandLine = Console.ReadLine();

                    RoverModelList[i] = _service.CalculateRoverCoordinates(Width, Height, RoverPathCommandLine, PositionX, PositionY, Direction);
                }

                Console.WriteLine("Output:");

                for (int i = 0; i < RoverNumber; i++)
                {
                    Console.WriteLine(RoverModelList[i].PositionX + " " + RoverModelList[i].PositionY + " " + RoverModelList[i].Direction);

                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
