using MindBox.SquareCalculator.Integration;
using MindBox.SquareCalculator.Shapes;
using MindBox.SquareCalculator.Visitor;
using Moq;

namespace Mindbox.SquareCalculator.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;
        public CalculatorTests()
        {
            var visitorMock = new Mock<IShapeVisitor>();
            visitorMock.Setup(m => m.GetSquare(It.IsAny<Circle>())).Returns(12.0);
            visitorMock.Setup(m => m.GetSquare(It.IsAny<Triangle>())).Returns(15.0);
            visitorMock.Setup(m => m.GetSquare(It.IsAny<RectangularTriangle>())).Returns(25.0);
            _calculator = new Calculator(visitorMock.Object);
        }

        #region GetSquareShapeAsync one shape

        [Theory]
        [InlineData(nameof(Circle), 12, 1.0)]
        [InlineData(nameof(Circle), 12, 5.25)]
        public async Task GetSquareShapeAsync_Circle(string expectType, double expectSquare, double radius)
        {
            var result = await _calculator.GetSquareShapeAsync(new Circle(radius));
            Assert.True(result.TypeShape == expectType && result.Square == expectSquare);
        }

        [Theory]
        [InlineData(nameof(Triangle), 15, 13, 7, 16)]
        [InlineData(nameof(Triangle), 15, 13, 5, 16)]
        public async Task GetSquareShapeAsync_Triangle(string expectType, double expectSquare, double a, double b, double c)
        {
            var result = await _calculator.GetSquareShapeAsync(new Triangle(a, b, c));
            Assert.True(result.TypeShape == expectType && result.Square == expectSquare);
        }

        [Theory]
        [InlineData(nameof(RectangularTriangle), 25, 3, 4, 5 )]
        [InlineData(nameof(RectangularTriangle), 25, 5, 12, 13)]
        public async Task GetSquareShapeAsync_RectangularTriangle(string expectType, double expectSquare, double a, double b, double c)
        {
            var result = await _calculator.GetSquareShapeAsync(new Triangle(a, b, c));
            Assert.True(result.TypeShape == expectType && result.Square == expectSquare);
        }

        [Theory]
        [InlineData(null)]
        public async Task GetSquareShapeAsync_CircleException(Circle shape)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => { await _calculator.GetSquareShapeAsync(shape); });
        }

        [Theory]
        [InlineData(null)]
        public async Task GetSquareShapeAsync_TriangleException(Triangle shape)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => { await _calculator.GetSquareShapeAsync(shape); });
        }

        #endregion

        #region GetSquareShapeAsync list shape

        [Theory]
        [InlineData(nameof(Circle), 12, 1.0)]
        [InlineData(nameof(Circle), 12, 5.25)]
        public async Task GetSquareShapeAsync_ListCircle(string expectType, double expectSquare, double radius)
        {
            var result = await _calculator.GetSquareShapeAsync([new Circle(radius), new Circle(radius + 5)]);
            result.ForEach(r => Assert.True(r.TypeShape == expectType && r.Square == expectSquare));
        }

        [Theory]
        [InlineData(nameof(Triangle), 15, 13, 7, 16)]
        [InlineData(nameof(Triangle), 15, 13, 5, 16)]
        public async Task etSquareShapeAsync_ListTriangle(string expectType, double expectSquare, double a, double b, double c)
        {
            var result = await _calculator.GetSquareShapeAsync([new Triangle(a, b, c), new Triangle(a + 2, b + 2, c + 2)]);
            result.ForEach(r => Assert.True(r.TypeShape == expectType && r.Square == expectSquare));
        }

        [Theory]
        [InlineData(nameof(RectangularTriangle), 25, 3, 4, 5)]
        [InlineData(nameof(RectangularTriangle), 25, 5, 12, 13)]
        public async Task etSquareShapeAsync_ListRectungularTriangle(string expectType, double expectSquare, double a, double b, double c)
        {
            var result = await _calculator.GetSquareShapeAsync([new Triangle(a, b, c), new Triangle(a * 2, b * 2, c * 2)]);
            result.ForEach(r => Assert.True(r.TypeShape == expectType && r.Square == expectSquare));
        }

        [Theory]
        [InlineData(15, 13, 7, 16, 12, 2, 25, 3, 4, 5)]
        public async Task etSquareShapeAsync_ListShape(double expectSquareTriangle, double a, double b, double c, 
            double expectSquareCircle, double radius, double expectedRectangle, double rA, double rB, double rC)
        {
            var result = await _calculator.GetSquareShapeAsync([new Triangle(a, b, c), new Circle(radius), new Triangle(rA , rB , rC)]);
            var triangleResult = result.First(r => r.TypeShape == nameof(Triangle));
            var circleResult = result.First(r => r.TypeShape == nameof(Circle));
            var rectungularResult = result.First(r => r.TypeShape == nameof(RectangularTriangle));

            Assert.True(triangleResult.Square == expectSquareTriangle && 
                circleResult.Square == expectSquareCircle &&
                rectungularResult.Square == expectedRectangle);
        }

        [Fact]
        public async Task GetSquareShapeAsync_ListNullException()
        {
            IShape[] shape = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async () => { await _calculator.GetSquareShapeAsync(shape); });
        }

        [Fact]
        public async Task GetSquareShapeAsync_ListEmptyException()
        {
            IShape[] shape = new IShape[0];
            await Assert.ThrowsAsync<ArgumentNullException>(async () => { await _calculator.GetSquareShapeAsync(shape); });
        }

        #endregion

    }
}