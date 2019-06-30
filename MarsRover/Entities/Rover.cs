using System;
using MarsRover.Enums;
using MarsRover.Helpers;

namespace MarsRover.Classes
{
    public class Rover
    {
        public Coordinate _coordinate;
        public OrientationEnum _orientation;
        public Plateau _plateau;


        public Rover(Coordinate coordinate, OrientationEnum orientation, Plateau plateau)
        {
            _coordinate = coordinate;
            _orientation = orientation;
            _plateau = plateau;
        }

        public Coordinate Coordinate
        {
            get => _coordinate;
            set => _coordinate = value;
        }

        public OrientationEnum Orientation
        {
            get => _orientation;
            set => _orientation = value;
        }

        public Plateau Plateau
        {
            get => _plateau;
            set => _plateau = value;
        }

        internal void TurnLeft()
        {
            Orientation = Orientation == OrientationEnum.East ? OrientationEnum.North : (OrientationEnum)((int)Orientation + 1);

        }

        internal void TurnRight()
        {
            Orientation = Orientation == OrientationEnum.North ? OrientationEnum.East : (OrientationEnum)((int)Orientation - 1);
        }

        internal void Move()
        {
            switch (Orientation)
            {
                case OrientationEnum.North:
                    Coordinate.Y++;
                    break;
                case OrientationEnum.West:
                    Coordinate.X--;
                    break;
                case OrientationEnum.South:
                    Coordinate.Y--;
                    break;
                case OrientationEnum.East:
                    Coordinate.X++; 
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (Coordinate.X <= Plateau.Coordinate.X && Coordinate.Y <= Plateau.Coordinate.Y) return;

            Console.WriteLine($"Oops! Your rover has fallen off of Mars! It's last known position was: {Coordinate.X} {Coordinate.Y} {Orientation.ToString()}");
            Console.ReadLine();
            throw new ArgumentOutOfRangeException();
        }
    }
}
