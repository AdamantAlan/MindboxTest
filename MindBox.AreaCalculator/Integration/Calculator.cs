using MindBox.SquareCalculator.Shapes;
using MindBox.SquareCalculator.Visitor;

namespace MindBox.SquareCalculator.Integration
{
    public class Calculator : ICalculator
    {
        private readonly IShapeVisitor _visitor;

        public Calculator(IShapeVisitor visitor)
        {
            _visitor = visitor;
        }

        public async Task<SquareCalculatorResult> GetSquareShapeAsync(IShape shape) => await Task.Run(() => 
                new SquareCalculatorResult()
                {
                    TypeShape = nameof(shape),
                    Area = shape.GetSquare(_visitor)
                });

        public async Task<IEnumerable<SquareCalculatorResult>> GetSquareShapeAsync(IEnumerable<IShape> shapes) => await Task.Run(() => 
            {
                return shapes.Select(ss => new SquareCalculatorResult()
                {
                    TypeShape = ss.GetType().Name,
                    Area = ss.GetSquare(_visitor)
                });
            });
    }
}
