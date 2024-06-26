using MindBox.SquareCalculator.Shapes;

namespace MindBox.SquareCalculator.Visitor
{
    /// <summary>
    /// Визитер для расчета площади фигур, вызывается фигурой
    /// <see cref="IShape"/>
    /// </summary>
    public interface IShapeVisitor
    {
        double GetSquare(Circle shape);

        double GetSquare(Triangle shape);

        double GetSquare(RectangularTriangle shape);
    }
}
