using System;
using MarsRover.Enums;
using MarsRover.Helpers;

namespace MarsRover.Classes
{
    public class Rover
    {
        public Coordinate _coordinate;
        public OrientationEnum _orientation;


        public Rover(Coordinate coordinate, OrientationEnum orientation)
        {
            _coordinate = coordinate;
            _orientation = orientation;
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
        }
    }
}
