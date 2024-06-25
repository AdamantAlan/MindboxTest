using Microsoft.Extensions.DependencyInjection;
using MindBox.SquareCalculator.Visitor;

namespace MindBox.SquareCalculator.Integration
{
    public static class ConfiguratorCalculator
    {
        public static void AddService(IServiceCollection services)
        {
            services.AddTransient<IShapeVisitor, ShapeVisitor>()
                .AddTransient<ICalculator, Calculator>();
        }
    }
}
