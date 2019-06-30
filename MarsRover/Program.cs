using System;
using System.Dynamic;
using MarsRover.Classes;
using MarsRover.Enums;
using MarsRover.Helpers;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter plateau dimensions:");
            var linePlateau = Console.ReadLine();
            var plateauNumbers = linePlateau.Split();
            var plateauCoordinates = Array.ConvertAll(plateauNumbers, int.Parse);

            var plateau = new Plateau
            {
                Coordinate = new Coordinate
                {
                    X = plateauCoordinates[0],
                    Y = plateauCoordinates[1]
                }
            };

            Console.WriteLine("Enter first rover's coordinates and orientation:");
            var lineRover0 = Console.ReadLine();
            var roverCoordinates0 = lineRover0.Split();
            var rover = new Rover(new Coordinate { X = Convert.ToInt32(roverCoordinates0[0]), Y = Convert.ToInt32(roverCoordinates0[1]) }, EnumHelper<OrientationEnum>.GetValueFromName(roverCoordinates0[2]));


            Console.WriteLine("Enter first rover's movements:");
            var lineMovement0 = Console.ReadLine();
            var movements = lineMovement0.ToCharArray();
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

            Console.WriteLine($"Your rovers coordinates are as follows: {rover.Coordinate.X} {rover.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover.Orientation)}");
          
            Console.ReadKey();
        }
    }
}
