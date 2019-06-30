using System;
using MarsRover.Domain;
using MarsRover.Enums;
using MarsRover.Helpers;

namespace MarsRover.Service
{
    internal interface IRoverService
    {
        Rover GetRover(string lineRover, Plateau plateau,Coordinate coordinate);
        void MoveRover(string lineMovement, Rover rover);
    }
    internal class RoverService :IRoverService
    {
        public Rover GetRover(string lineRover, Plateau plateau, Coordinate coordinate)
        {
            var roverCoordinates0 = lineRover.Split();
            var rover = new Rover(
                coordinate,EnumHelper<OrientationEnum>.GetValueFromName(roverCoordinates0[2]), plateau);
            return rover;
        }

        public void MoveRover(string lineMovement, Rover rover)
        {
            var movements = lineMovement.ToCharArray();
            foreach (var movement in movements)
            {
                var movementEnum = EnumHelper<MovementEnum>.GetValueFromName(movement.ToString());
                switch (movementEnum)
                {
                    case MovementEnum.Left:
                        rover.TurnLeft();
                        break;
                    case MovementEnum.Right:
                        rover.TurnRight();
                        break;
                    case MovementEnum.Move:
                        rover.Move();
                        break;
                    default:
                        Console.WriteLine("Oops! You have not entered a valid movement.");
                        Console.WriteLine("Enter L to turn left, R to turn right and M to move forward.");
                        Console.WriteLine("This program will be aborted after you press enter.");
                        Console.ReadLine();
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
