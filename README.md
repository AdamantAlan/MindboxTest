
# Тестовое задание для Mindbox

Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по
радиусу и треугольника по трем сторонам. 

## Проект состоит из
    - Mindbox клиентская сборка
    - Mindbox.SquareCalculator сборка для расчетов площади
    - Mindbox.SquareCalculator.Tests тесты для библиотеки

## Использование
    1) Зарегистрируйте зависимости в проекте, через MindBox.SquareCalculator.Integration.ConfiguratorCalculator
    методом AddService
    
```csharp
    var services = new ServiceCollection();
    ConfiguratorCalculator.AddService(services);
```

    2) Получите из контейнера интерфейс ICalculator и воспользуйтесь функциями:

```csharp
Task<SquareCalculatorResult> GetSquareShapeAsync(IShape shape)
```
или
```csharp
Task<List<SquareCalculatorResult>> GetSquareShapeAsync(IEnumerable<IShape> shapes)
```
    3) Получите результат - структуру(или массив структур)
 ```csharp
record struct SquareCalculatorResult(string TypeShape, double? Square)
```

## Пример
```csharp
ConfiguratorCalculator.AddService(services);
var calc = provider.GetRequiredService<ICalculator>();

var result = await calc.GetSquareShapeAsync(new Triangle(3, 4, 5)).ConfigureAwait(false);
Console.WriteLine(result.ToString());

var results = await calc.GetSquareShapeAsync([new Circle(12), new Triangle(13, 7, 16), new Triangle(3, 4, 5)])
.ConfigureAwait(false);
results.ForEach(x => Console.WriteLine(x.ToString()));
```
## Добавление новой формы
    1) Создайте реализацию интерфейса MindBox.SquareCalculator.Shapes.IShape, добавьте ему необходимые свойства для расчета площади
    2) В MindBox.SquareCalculator.Visitor.IShapeVisitor добавьте новый метод для своей фигуры и реализуйте в 
    MindBox.SquareCalculator.Visitor.ShapeVisitor метод для расчета площади

## Пример
 ```csharp
public record Triangle(double SideA, double SideB, double SideC) : IShape
{
    public double GetSquare(IShapeVisitor visitor) => visitor.GetSquare(this);
}
```
```csharp
public interface IShapeVisitor
{
    // другие методы

    double GetSquare(Triangle shape);
}
```
```csharp
internal sealed class ShapeVisitor : IShapeVisitor
{
    // другие методы
  
    public double GetSquare(Triangle shape)
    {
        if (shape.SideA <= 0 || shape.SideB <= 0 || shape.SideC <= 0)
            throw new ArgumentException("Sides of the triangle are less than or equal to zero");

        double p = (shape.SideA + shape.SideB + shape.SideC) / 2;
        return Math.Round(Math.Sqrt(p * (p - shape.SideA) * (p - shape.SideB) * (p - shape.SideC)), 2);
    }
}
```