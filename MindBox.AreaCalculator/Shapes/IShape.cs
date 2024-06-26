using MindBox.SquareCalculator.Visitor;

namespace MindBox.SquareCalculator.Shapes
{
    /// <summary>
    /// Абстракция для геометрических форм
    /// <see cref="Circle"/>
    /// <see cref="Triangle"/>
    /// <see cref="RectangularTriangle"/>
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Рассчитать площадь фигуры
        /// </summary>
        /// <param name="visitor">передача исполняющей функции визитеру</param>
        /// <returns>double число равное площади фигуры с округлением до двух знаков после запятой</returns>
        double GetSquare(IShapeVisitor visitor);
    }
}
