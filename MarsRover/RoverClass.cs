using System;
using MarsRover.Classes;
using MarsRover.Enums;
using MarsRover.Helpers;

namespace MarsRover
{
    internal interface IRoverClass
    {
        Rover GetRover(string lineRover, Plateau plateau);
    }
    internal class RoverClass
    {
        private Rover GetRover(string lineRover, Plateau plateau)
        {
            var roverCoordinates0 = lineRover.Split();
            var rover = new Rover(
                new Coordinate { X = Convert.ToInt32(roverCoordinates0[0]), Y = Convert.ToInt32(roverCoordinates0[1]) },
                EnumHelper<OrientationEnum>.GetValueFromName(roverCoordinates0[2]), plateau);
            return rover;
        }
    }
}
