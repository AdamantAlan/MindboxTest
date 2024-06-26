﻿using Microsoft.Extensions.DependencyInjection;
using MindBox.SquareCalculator.Integration;
using MindBox.SquareCalculator.Shapes;

namespace MindBox
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Тестовое задание для Mindbox!");

            var services = new ServiceCollection();
            ConfiguratorCalculator.AddService(services);
            var provider = services.BuildServiceProvider();
            var calc = provider.GetRequiredService<ICalculator>();

            //Проверка, что все работает по одной фигуре
            var result = await calc.GetSquareShapeAsync(new Triangle(3, 4, 5)).ConfigureAwait(false);
            Console.WriteLine(result.ToString());
            //Проверка, что все работает по массиву фигур
            List<IShape> shapes = [new Circle(12), new Triangle(13, 7, 16), new Triangle(3, 4, 5)];
            var results = await calc.GetSquareShapeAsync(shapes).ConfigureAwait(false);
            results.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}