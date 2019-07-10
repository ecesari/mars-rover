using System.Collections.Generic;

namespace MarsRover.Domain
{
    public class Plateau
    {
        public Plateau()
        {
            Beacons = new List<Beacon>();
        }
        public Coordinate Coordinate { get; set; }
        public IList<Beacon> Beacons { get; set; }
    }
}
