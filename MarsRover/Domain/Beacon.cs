using System;
using MarsRover.Enums;

namespace MarsRover.Domain
{
    public class Beacon
    {
        public Coordinate _coordinate;
        public OrientationEnum _orientation;


        public Beacon(Coordinate coordinate, OrientationEnum orientation)
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

    }
}
