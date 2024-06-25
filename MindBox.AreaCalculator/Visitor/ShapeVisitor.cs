using MindBox.SquareCalculator.Shapes;

namespace MindBox.SquareCalculator.Visitor
{
    internal sealed class ShapeVisitor : IShapeVisitor
    {
        public double GetSquare(Circle shape)
        {
            if (shape.Radius <= 0)
                throw new ArgumentException("Radius is less than or equal to zero");

            return Math.PI * Math.Pow(shape.Radius, 2);
        }
        

        public double GetSquare(Triangle shape)
        {
            if (shape.SideA <= 0 || shape.SideB <= 0 || shape.SideC <= 0)
                throw new ArgumentException("Sides of the triangle are less than or equal to zero");

            double p = (shape.SideA + shape.SideB + shape.SideC) / 2;
            return Math.Sqrt(p * (p - shape.SideA) * (p - shape.SideB) * (p - shape.SideC));
        }
    }
}
