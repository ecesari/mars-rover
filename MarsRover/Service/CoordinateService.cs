using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Domain;

namespace MarsRover.Service
{
    internal interface ICoordinateService
    {
        Coordinate GetCoordinate(int x, int y);
    }

    internal class CoordinateService:ICoordinateService
    {
        public Coordinate GetCoordinate(int x, int y)
        {
            return new Coordinate
            {
                X = x,
                Y = y
            };
        }
    }
}
