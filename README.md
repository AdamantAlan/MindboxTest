
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
// Зарегистрируйте зависимости в проекте
ConfiguratorCalculator.AddService(services);
// Получите из контейнера интерфейс ICalculator
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

# Второе тестовое задание для Mindbox
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много
категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар
«Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно
выводиться.

```sql
-- Создание таблицы продукты
CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName NVARCHAR(100)
);

-- Создание таблицы категории
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY,
    CategoryName NVARCHAR(100)
);

-- Создание таблицы-связки для отношения "многие ко многим"
CREATE TABLE ProductCategories (
    ProductId INT,
    CategoryId INT,
    PRIMARY KEY (ProductId, CategoryId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- Заполнение таблицы "Продукты"
INSERT INTO Products (ProductId, ProductName) VALUES
(1, 'Product 1'),
(2, 'Product 2'),
(3, 'Product 3'),
(4, 'Product 4'),
(5, 'Product 5'),
(6, 'Product 6');

-- Заполнение таблицы "Категории"
INSERT INTO Categories (CategoryId, CategoryName) VALUES
(1, 'Category 1'),
(2, 'Category 2'),
(3, 'Category 3'),
(4, 'Category 4');

-- Заполнение таблицы-связки "Продукты-Категории"
INSERT INTO ProductCategories (ProductId, CategoryId) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2);

-- Индексы будут созданы с PK, повторно создавать не нужно
SELECT *
FROM sys.indexes
WHERE object_id = OBJECT_ID('Products') or object_id = OBJECT_ID('Categories') or object_id = OBJECT_ID('ProductCategories');

-- Целевой запрос
SELECT p.ProductName, c.CategoryName
FROM Products p
 LEFT JOIN ProductCategories pc ON p.ProductId = pc.ProductId
 LEFT JOIN Categories c ON pc.CategoryId = c.CategoryId
ORDER BY p.ProductName;
```
## скрипт доступен в репозитории файлом MindBoxTest2.sql