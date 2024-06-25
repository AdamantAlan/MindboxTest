using MindBox.SquareCalculator.Shapes;
using MindBox.SquareCalculator.Visitor;

namespace Mindbox.SquareCalculator.Tests
{
    public class ShapeVisitorTests
    {
        private readonly ShapeVisitor _visitor;
        public ShapeVisitorTests()
        {
            _visitor = new ShapeVisitor();
        }

        #region Circle

        [Theory]
        [InlineData(10, 314.16)]
        [InlineData(1, 3.14)]
        public void GetSquare_CircleSquare(double radius, double expect)
        {
            var result = _visitor.GetSquare(new Circle(radius));
            Assert.Equal(result, expect);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        public void GetSquare_CircleException(double radius)
        {
            Assert.Throws<ArgumentException>(() => { _visitor.GetSquare(new Circle(radius)); });
        }

        #endregion

        #region Triangle

        [Theory]
        [InlineData(13, 7, 16, 44.5)]
        [InlineData(13, 5, 16, 28.57)]
        public void GetSquare_TriangleSquare(double a, double b, double c, double expect)
        {
            var result = _visitor.GetSquare(new Triangle(a, b, c));
            Assert.Equal(result, expect);
        }

        [Theory]
        [InlineData(-1, 7, 16)]
        [InlineData(13, -2, 16)]
        [InlineData(13, 2, -3)]
        [InlineData(0, 7, 16)]
        [InlineData(13, 0, 16)]
        [InlineData(13, 2, 0)]
        public void GetSquare_TriangleExceptions(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => { _visitor.GetSquare(new Triangle(a, b, c)); });
        }

        #endregion
    }
}