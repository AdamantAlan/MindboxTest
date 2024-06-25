using Microsoft.Extensions.DependencyInjection;
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

            //Проверка, что все работает
            var result = await calc.GetSquareShapeAsync(new Circle(12)).ConfigureAwait(false);
            Console.WriteLine(result.ToString());
            List<IShape> shapes = [new Circle(12), new Triangle(13, 7, 16), new Triangle(13, 5, 16)];
            var results = await calc.GetSquareShapeAsync(shapes).ConfigureAwait(false);
            results.ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}

//todo
//проверка на прямоугольный треугольник
//эксершены и логи
//тесты
