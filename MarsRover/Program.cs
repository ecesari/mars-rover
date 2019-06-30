using System;
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

            Console.WriteLine("Enter plateau dimensions:");
            var linePlateau = Console.ReadLine();
            var plateau = plateauService.GetPlateau(linePlateau);

            Console.WriteLine("Enter first rover's coordinates and orientation:");
            var lineRover = Console.ReadLine();
            var rover = roverService.GetRover(lineRover, plateau);


            Console.WriteLine("Enter first rover's movements:");
            var lineMovement = Console.ReadLine();
            roverService.MoveRover(lineMovement, rover);


            Console.WriteLine("Enter second rover's coordinates and orientation:");
            var lineRover1 = Console.ReadLine();
            var rover1 = roverService.GetRover(lineRover1, plateau);


            Console.WriteLine("Enter second rover's movements:");
            var lineMovement1 = Console.ReadLine();
            roverService.MoveRover(lineMovement1, rover1);

            Console.WriteLine($"Your first rover's coordinates are as follows: {rover.Coordinate.X} {rover.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover.Orientation)}");
            Console.WriteLine($"Your second rover's coordinates are as follows: {rover1.Coordinate.X} {rover1.Coordinate.Y} {EnumHelper<OrientationEnum>.GetDisplayValue(rover1.Orientation)}");
            Console.ReadKey();
        }


        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IRoverService, RoverService>();
            collection.AddScoped<IPlateauService, PlateauService>();
            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}