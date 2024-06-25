using MindBox.SquareCalculator.Visitor;

namespace MindBox.SquareCalculator.Shapes
{
    public sealed record Triangle(double SideA, double SideB, double SideC) : IShape
    {
        public double GetSquare(IShapeVisitor visitor) => visitor.GetSquare(this);
    }
}
