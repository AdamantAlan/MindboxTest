using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBox.SquareCalculator.Shapes
{
    public sealed record RectangularTriangle : Triangle
    {
        public RectangularTriangle(double KatetA, double KatetB, double Hipotenusa) : base(KatetA, KatetB, Hipotenusa)
        {
        }
    }
}
