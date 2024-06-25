using MindBox.SquareCalculator.Shapes;

namespace MindBox.SquareCalculator.Integration
{
    public interface ICalculator
    {
        Task<IEnumerable<SquareCalculatorResult>> GetSquareShapeAsync(IEnumerable<IShape> shapes);
        Task<SquareCalculatorResult> GetSquareShapeAsync(IShape shape);
    }
}
