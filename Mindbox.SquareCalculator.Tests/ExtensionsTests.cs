
using MindBox.SquareCalculator.Extensions;
using MindBox.SquareCalculator.Shapes;
using MindBox.SquareCalculator.Visitor;
using Moq;

namespace Mindbox.SquareCalculator.Tests
{
    public class ExtensionsTests
    {
        #region TriangleExtentions

        [Theory]
        [InlineData(13,7,16)]
        [InlineData(13, 5, 16)]
        public void GetIfRectangular_GetTriangle(double a, double b, double c)
        {
            var result = new Triangle(a, b, c).GetIfRectangular();
            Assert.IsType<Triangle>(result);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(13, 12, 5)]
        [InlineData(7, 25, 24)]
        public void GetIfRectangular_GetRectangularTriangle(double a, double b, double c)
        {
            var result = new Triangle(a, b, c).GetIfRectangular();
            Assert.IsType<RectangularTriangle>(result);
        }

        #endregion


        #region IEnumerableIShapeExtensions

        [Theory]
        [InlineData(13, 7, 16)]
        [InlineData(13, 5, 16)]
        public void ShapesWithRectangularTriangle_GetTriangle(double a, double b, double c)
        {
            var result = new List<IShape> { new Triangle(a, b, c), new Circle(5) }.ShapesWithRectangularTriangle();
            Assert.IsType<Triangle>(result.FirstOrDefault(r => r is Triangle));
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(13, 12, 5)]
        [InlineData(7, 25, 24)]
        public void ShapesWithRectangularTriangle_GetRectangularTriangle(double a, double b, double c)
        {
            var result = new List<IShape> { new Triangle(a, b, c), new Circle(5) }.ShapesWithRectangularTriangle();
            Assert.IsType<RectangularTriangle>(result.FirstOrDefault(r => r is RectangularTriangle));
        }

        #endregion

    }
}
