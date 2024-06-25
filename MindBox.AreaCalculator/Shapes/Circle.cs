using MindBox.SquareCalculator.Visitor;

namespace MindBox.SquareCalculator.Shapes
{
    public sealed record Circle(double Radius) : IShape
    {
        public double GetSquare(IShapeVisitor visitor) => visitor.GetSquare(this);
    }
}
