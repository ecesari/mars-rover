using System;
using MarsRover.Domain;

namespace MarsRover.Service
{
    internal interface IPlateauService
    {
        Plateau GetPlateau(string linePlateau);
    }
    internal class PlateauService :IPlateauService
    {
        public  Plateau GetPlateau(string linePlateau)
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
