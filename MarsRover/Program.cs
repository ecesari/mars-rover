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



            Console.WriteLine($"Your first rover's coordinates are as follows: {rover.Coordinate.X} {rover.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover.Orientation)}");
            Console.WriteLine($"Your second rover's coordinates are as follows: {rover1.Coordinate.X} {rover1.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover1.Orientation)}");
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