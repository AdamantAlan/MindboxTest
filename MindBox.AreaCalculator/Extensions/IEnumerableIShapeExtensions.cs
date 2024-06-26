using MindBox.SquareCalculator.Shapes;

namespace MindBox.SquareCalculator.Extensions
{
    internal static class IEnumerableIShapeExtensions
    {
        /// <summary>
        /// проверка есть ли прямоугольный треугольник в массиве
        /// </summary>
        /// <see cref="Triangle"/>
        /// <see cref="RectangularTriangle"/>
        /// <param name="shapes">массив над котором проверяется вхождение прямоугольного треугольника</param>
        /// <returns>массив с заменой треугольников на прямоугольные треугольники</returns>
        public static IEnumerable<IShape> ShapesWithRectangularTriangle(this IEnumerable<IShape> shapes) =>
            shapes.Where(s => s is not Triangle).Union(shapes.Where(s => s is Triangle).Select(s => (s as Triangle)!.GetIfRectangular()));
    }
}
