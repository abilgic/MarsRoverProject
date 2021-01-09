using MarsRoverProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverProject.Services
{
    public interface IRoverService
    {
        RoverModel CalculateRoverCoordinates(int Width, int Height, string RoverPathCommandLine, int PositionX, int PositionY, string Direction);
    }
}
