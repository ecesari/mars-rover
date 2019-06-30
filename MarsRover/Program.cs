using System;
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
            var plateau = GetPlateau(linePlateau);

            Console.WriteLine("Enter first rover's coordinates and orientation:");
            var lineRover = Console.ReadLine();
            var rover = GetRover(lineRover, plateau);


            Console.WriteLine("Enter first rover's movements:");
            var lineMovement = Console.ReadLine();
            MoveRover(lineMovement, rover);


            Console.WriteLine("Enter second rover's coordinates and orientation:");
            var lineRover1 = Console.ReadLine();
            var rover1 = GetRover(lineRover1, plateau);


            Console.WriteLine("Enter second rover's movements:");
            var lineMovement1 = Console.ReadLine();
            MoveRover(lineMovement1, rover1);

            Console.WriteLine($"Your first rover's coordinates are as follows: {rover.Coordinate.X} {rover.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover.Orientation)}");
            Console.WriteLine($"Your second rover's coordinates are as follows: {rover1.Coordinate.X} {rover1.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover1.Orientation)}");
            Console.ReadKey();
        }

        private static void MoveRover(string lineMovement, Rover rover)
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

        private static Rover GetRover(string lineRover, Plateau plateau)
        {
            var roverCoordinates0 = lineRover.Split();
            var rover = new Rover(
                new Coordinate {X = Convert.ToInt32(roverCoordinates0[0]), Y = Convert.ToInt32(roverCoordinates0[1])},
                EnumHelper<OrientationEnum>.GetValueFromName(roverCoordinates0[2]), plateau);
            return rover;
        }

        private static Plateau GetPlateau(string linePlateau)
        {
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
            return plateau;
        }
    }
}
