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

        public async Task<SquareCalculatorResult> GetSquareShapeAsync(IShape shape)
        {
            if (shape is null)
                throw new ArgumentNullException($"{nameof(shape)} is null");

            return await Task.Run(() => new SquareCalculatorResult()
            {
                TypeShape = nameof(shape),
                Area = shape!.GetSquare(_visitor)
            });
        }

        public async Task<List<SquareCalculatorResult>> GetSquareShapeAsync(IEnumerable<IShape> shapes)
        {
            if (shapes is null || !shapes.Any())
                throw new ArgumentNullException($"{nameof(shapes)} is null or empty");

            return await Task.Run(() =>
            {
                return shapes.Select(ss => new SquareCalculatorResult()
                {
                    TypeShape = ss.GetType().Name,
                    Area = ss.GetSquare(_visitor)
                }).ToList();
            });
        }
    }
}
