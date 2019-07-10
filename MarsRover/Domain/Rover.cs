using System;
using System.Linq;
using MarsRover.Enums;

namespace MarsRover.Domain
{
    public class Rover
    {
        private Coordinate _coordinate;
        private OrientationEnum _orientation;
        private Plateau _plateau;
        private Coordinate _previousCoordinate;
        private OrientationEnum _previousOrientation;
        public bool Status { get; set; }


        public Rover(Coordinate coordinate, OrientationEnum orientation, Plateau plateau)
        {
            _coordinate = coordinate;
            _orientation = orientation;
            _plateau = plateau;
            Status = true;
            _previousCoordinate = new Coordinate();
        }


        public Coordinate PreviousCoordinate
        {
            get => _previousCoordinate;
            set => _previousCoordinate = value;
        }

        public OrientationEnum PreviousOrientation
        {
            get => _previousOrientation;
            set => _previousOrientation = value;
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
            var plateau = Plateau;
            var beacons = plateau.Beacons;
            var beaconExists = beacons.Any(x => x.Orientation == Orientation && x.Coordinate.X == Coordinate.X && x.Coordinate.Y == Coordinate.Y);
            if (beaconExists) return;

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

            if (Coordinate.X <= Plateau.Coordinate.X && Coordinate.Y <= Plateau.Coordinate.Y && Coordinate.X >= 0 && Coordinate.Y >= 0)
            {
                return;
            }


            Status = false;
            var beacon = new Beacon(new Coordinate
            {
                X = PreviousCoordinate.X,
                Y = PreviousCoordinate.Y
            },Orientation = PreviousOrientation);
            plateau.Beacons.Add(beacon);

            
            
        }
    }
}
