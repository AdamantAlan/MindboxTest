namespace MindBox.SquareCalculator
{
    /// <summary>
    /// Результат выполнения рассчета площади 
    /// </summary>
    /// <param name="TypeShape">Тип фигуры</param>
    /// <param name="Square">Площадь</param>
    public record struct SquareCalculatorResult(string TypeShape, double? Square);
}
