using MindBox.SquareCalculator.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBox.SquareCalculator.Extensions
{
    internal static class IEnumerableIShapeExtensions
    {
        public static IEnumerable<IShape> ShapesWithRectangularTriangle(this IEnumerable<IShape> shapes) =>
            shapes.Where(s => s is not Triangle).Union(shapes.Where(s => s is Triangle).Select(s => (s as Triangle)!.GetIfRectangular()));
    }
}
