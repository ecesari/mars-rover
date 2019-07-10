using System;
using MarsRover.Domain;
using MarsRover.Enums;
using MarsRover.Helpers;
using MarsRover.Service;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            var roverService = _serviceProvider.GetService<IRoverService>();
            var plateauService = _serviceProvider.GetService<IPlateauService>();
            var coordinateService = _serviceProvider.GetService<ICoordinateService>();

            Console.WriteLine("Enter plateau dimensions:");
            var linePlateau = Console.ReadLine();
            var array = linePlateau.GetIntArrayByString();
            var coordinate = coordinateService.GetCoordinate(array[0],array[1]);
            var plateau = plateauService.GetPlateau(coordinate);

            Console.WriteLine("Enter first rover's coordinates and orientation:");
            var rover = Rover(Console.ReadLine(), coordinateService, roverService, plateau);


            Console.WriteLine("Enter first rover's movements:");
            var lineMovement = Console.ReadLine();
            roverService.MoveRover(lineMovement, rover);


            Console.WriteLine("Enter second rover's coordinates and orientation:");
            var rover1 = Rover(Console.ReadLine(), coordinateService, roverService, plateau);



            Console.WriteLine("Enter second rover's movements:");
            var lineMovement1 = Console.ReadLine();
            roverService.MoveRover(lineMovement1, rover1);


            Console.WriteLine("Enter third rover's coordinates and orientation:");
            var rover2 = Rover(Console.ReadLine(), coordinateService, roverService, plateau);



            Console.WriteLine("Enter third rover's movements:");
            var lineMovement2 = Console.ReadLine();
            roverService.MoveRover(lineMovement2, rover2);

   
            var result = !rover.Status ? 
                $"Your first rover's coordinates are as follows: {rover.PreviousCoordinate.X} {rover.PreviousCoordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover.PreviousOrientation)}" : $"Your first rover's coordinates are as follows: {rover.Coordinate.X} {rover.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover.Orientation)} RIP";
            Console.WriteLine(result);



            var result1 = !rover1.Status ? $"Your first rover's coordinates are as follows: {rover1.PreviousCoordinate.X} {rover1.PreviousCoordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover1.PreviousOrientation)}" : $"Your first rover's coordinates are as follows: {rover1.Coordinate.X} {rover1.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover1.Orientation)} RIP";
            Console.WriteLine(result1);



            var result2 = !rover2.Status ? $"Your first rover's coordinates are as follows: {rover2.PreviousCoordinate.X} {rover2.PreviousCoordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover2.PreviousOrientation)}" : $"Your first rover's coordinates are as follows: {rover2.Coordinate.X} {rover2.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover2.Orientation)} RIP";
            Console.WriteLine(result2);



            Console.ReadKey();
        }

        private static Rover Rover(string line, ICoordinateService coordinateService, IRoverService roverService,
            Plateau plateau)
        {
            var arrayRoverString = line.GetStringArrayByString();
            var coordinateRover =
                coordinateService.GetCoordinate(Convert.ToInt32(arrayRoverString[0]), Convert.ToInt32(arrayRoverString[1]));
            var rover = roverService.GetRover(line, plateau, coordinateRover);
            return rover;
        }


        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IRoverService, RoverService>();
            collection.AddScoped<IPlateauService, PlateauService>();
            collection.AddScoped<ICoordinateService, CoordinateService>();
            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}