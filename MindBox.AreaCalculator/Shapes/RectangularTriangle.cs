using MindBox.SquareCalculator.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBox.SquareCalculator.Shapes
{
    public sealed record RectangularTriangle(double SideA, double SideB, double Hipotenusa) : IShape
    {
        public double GetSquare(IShapeVisitor visitor) => visitor.GetSquare(this);
    }
}
