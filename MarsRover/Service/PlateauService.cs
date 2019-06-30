using MarsRover.Domain;

namespace MarsRover.Service
{
    internal interface IPlateauService
    {
        Plateau GetPlateau(Coordinate coordinate);
    }
    internal class PlateauService :IPlateauService
    {
        public Plateau GetPlateau(Coordinate coordinate)
        {
            var plateau = new Plateau
            {
                Coordinate = coordinate
            };
            return plateau;
        }


    }
}
