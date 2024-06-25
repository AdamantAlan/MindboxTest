using MindBox.SquareCalculator.Shapes;

namespace MindBox.SquareCalculator.Visitor
{
    internal sealed class ShapeVisitor : IShapeVisitor
    {
        public double GetSquare(Circle shape) => Math.PI * Math.Pow(shape.Radius, 2);
        

        public double GetSquare(Triangle shape)
        {
            double p = (shape.SideA + shape.SideB + shape.SideC) / 2;
            var t = Math.Sqrt(p * (p - shape.SideA) * (p - shape.SideB) * (p - shape.SideC));
            return Math.Sqrt(p * (p - shape.SideA) * (p - shape.SideB) * (p - shape.SideC));
        }
    }
}
