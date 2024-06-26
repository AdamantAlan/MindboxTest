using MindBox.SquareCalculator.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBox.SquareCalculator.Extensions
{
    internal static class TriangleExtensions
    {
        public static Triangle GetIfRectangular(this Triangle t)
        {
            var sides = new[] { t.SideA, t.SideB, t.SideC }.OrderBy(x => x).ToArray();
            var isRectangular = Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
            return isRectangular ? new RectangularTriangle(sides[0], sides[1], sides[2]) : t;
        }
    }
}
