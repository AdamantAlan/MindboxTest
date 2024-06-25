using MindBox.SquareCalculator.Visitor;

namespace MindBox.SquareCalculator.Shapes
{
    public interface IShape
    {
        double GetSquare(IShapeVisitor visitor);
    }
}
