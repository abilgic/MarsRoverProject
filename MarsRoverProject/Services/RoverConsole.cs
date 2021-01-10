using MarsRoverProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverProject.Services
{
    public class RoverConsole
    {
        private const int RoverNumber = 2;//Number of Rovers
        private readonly IRoverService _service;//Dependency Injection services
        public RoverConsole(IRoverService service)
        {
            _service = service;
        }

        //Do Rover Actions
        public void Run()
        {
            RoverModel[] RoverModelList = new RoverModel[RoverNumber];
            try
            {               
                startinput:
                    Console.WriteLine("Test Input:");
                    string AreaValuesLine = Console.ReadLine();

                string[] SplittedAreaValues = AreaValuesLine.Split(' ');               

                if (string.IsNullOrEmpty(SplittedAreaValues.ElementAtOrDefault(0)) || string.IsNullOrEmpty(SplittedAreaValues.ElementAtOrDefault(1)))
                {
                    goto startinput;
                }

                var Width = Convert.ToInt32(SplittedAreaValues[0]);
                var Height = Convert.ToInt32(SplittedAreaValues[1]);

                for (int i = 0; i < RoverNumber; i++)
                {                   
                    string RoverValuesLine = "";
                    RoverValuesLine = Console.ReadLine();
                    string[] SplittedRoverValues = RoverValuesLine.Split(' ');                  

                    if (string.IsNullOrEmpty(SplittedRoverValues.ElementAtOrDefault(0)) || string.IsNullOrEmpty(SplittedRoverValues.ElementAtOrDefault(1)) || string.IsNullOrEmpty(SplittedRoverValues.ElementAtOrDefault(2)))
                    {
                        goto startinput;
                    }

                    var PositionX = Convert.ToInt32(SplittedRoverValues[0]);
                    var PositionY = Convert.ToInt32(SplittedRoverValues[1]);
                    var Direction = SplittedRoverValues[2];

                    string RoverPathCommandLine = "";

                    RoverPathCommandLine = Console.ReadLine();

                    if (string.IsNullOrEmpty(RoverPathCommandLine))
                    {
                        goto startinput;
                    }

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
                Console.WriteLine(e);
                
            }
        }
    }
}
