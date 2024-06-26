using MindBox.SquareCalculator.Shapes;

namespace MindBox.SquareCalculator.Integration
{
    /// <summary>
    /// Калькулятор рассчета площади фигур
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// рассчитать площадь для каждой фигуры в массиве
        /// </summary>
        /// <see cref="IShape"/>
        /// <see cref="SquareCalculatorResult"/>
        /// <param name="shapes">массив фигур</param>
        /// <returns>результат выполнения рассчета</returns>
        Task<List<SquareCalculatorResult>> GetSquareShapeAsync(IEnumerable<IShape> shapes);

        /// <summary>
        /// рассчитать площадь одной фигуры
        /// </summary>
        /// <see cref="IShape"/>
        /// <see cref="SquareCalculatorResult"/>
        /// <param name="shape">фигура для рассчета площади</param>
        /// <returns>результат выполнения рассчета</returns>
        Task<SquareCalculatorResult> GetSquareShapeAsync(IShape shape);
    }
}
