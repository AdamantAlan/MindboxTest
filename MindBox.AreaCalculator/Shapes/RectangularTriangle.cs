using MindBox.SquareCalculator.Visitor;

namespace MindBox.SquareCalculator.Shapes
{
    public sealed record RectangularTriangle(double SideA, double SideB, double Hipotenusa) : IShape
    {
        public double GetSquare(IShapeVisitor visitor) => visitor.GetSquare(this);
    }
}
