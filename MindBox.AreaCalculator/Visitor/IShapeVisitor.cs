using MindBox.SquareCalculator.Shapes;

namespace MindBox.SquareCalculator.Visitor
{
    public interface IShapeVisitor
    {
        double GetSquare(Circle shape);
        double GetSquare(Triangle shape);
    }
}
