//using System;

//public class Rover 
//{
//    public IPosition RoverPosition { get; set; }
//    public Orientations RoverOrientation { get; set; }
//    public IPlateau RoverPlateau { get; set; }

//    public Rover(IPosition roverPosition, Orientations roverOrientation, IPlateau roverPlateau)
//    {
//        RoverPosition = roverPosition;
//        RoverOrientation = roverOrientation;
//        RoverPlateau = roverPlateau;
//    }

//    public void Process(string commands)
//    {
//        foreach (var command in commands)
//        {
//            switch (command)
//            {
//                case ('L'):
//                    TurnLeft();
//                    break;
//                case ('R'):
//                    TurnRight();
//                    break;
//                case ('M'):
//                    Move();
//                    break;
//                default:
//                    throw new ArgumentException(string.Format("Invalid value: {0}", command));
//            }
//        }
//    }

//    public bool IsRobotInsideBoundaries
//    {
//        get
//        {
//            bool isInsideBoundaries = false;
//            if (RoverPosition.X > RoverPlateau.PlateauPosition.X || RoverPosition.Y > RoverPlateau.PlateauPosition.Y)
//                isInsideBoundaries = true;
//            return isInsideBoundaries;
//        }
//    }

//    private void TurnLeft()
//    {
//        RoverOrientation = (RoverOrientation - 1) < Orientations.N ? Orientations.W : RoverOrientation - 1;
//    }

//    private void TurnRight()
//    {
//        RoverOrientation = (RoverOrientation + 1) > Orientations.W ? Orientations.N : RoverOrientation + 1;
//    }

//    private void Move()
//    {
//        if (RoverOrientation == Orientations.N)
//        {
//            RoverPosition.Y++;
//        }
//        else if (RoverOrientation == Orientations.E)
//        {
//            RoverPosition.X++;
//        }
//        else if (RoverOrientation == Orientations.S)
//        {
//            RoverPosition.Y--;
//        }
//        else if (RoverOrientation == Orientations.W)
//        {
//            RoverPosition.X--;
//        }
//    }

//    public override string ToString()
//    {
//        string printedRoverPosition = string.Format("{0} {1} {2}", RoverPosition.X, RoverPosition.Y, RoverOrientation.GetStringValue());
//        if (IsRobotInsideBoundaries)
//            printedRoverPosition =
//                string.Format("Rover outside the plateau, Rover position: {0} , plateau limit {1}",
//                              printedRoverPosition, RoverPlateau.PlateauPosition.ToString());

//        return printedRoverPosition;

//    }

//}

//public interface IPlateau
//{
//    IPosition PlateauPosition { get; }
//}

//public interface IPosition
//{
//}

//public class Plateau : IPlateau
//{
//    public IPosition PlateauPosition { get; private set; }

//    public Plateau(IPosition position)
//    {
//        PlateauPosition = position;
//    }
//}