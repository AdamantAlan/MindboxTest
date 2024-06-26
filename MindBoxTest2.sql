-- �������� ������� ��������
CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName NVARCHAR(100)
);

-- �������� ������� ���������
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY,
    CategoryName NVARCHAR(100)
);

-- �������� �������-������ ��� ��������� "������ �� ������"
CREATE TABLE ProductCategories (
    ProductId INT,
    CategoryId INT,
    PRIMARY KEY (ProductId, CategoryId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- ���������� ������� "��������"
INSERT INTO Products (ProductId, ProductName) VALUES
(1, 'Product 1'),
(2, 'Product 2'),
(3, 'Product 3'),
(4, 'Product 4'),
(5, 'Product 5'),
(6, 'Product 6');

-- ���������� ������� "���������"
INSERT INTO Categories (CategoryId, CategoryName) VALUES
(1, 'Category 1'),
(2, 'Category 2'),
(3, 'Category 3'),
(4, 'Category 4');

-- ���������� �������-������ "��������-���������"
INSERT INTO ProductCategories (ProductId, CategoryId) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2);

-- ������� ����� ������� � PK, �������� ��������� �� �����
SELECT *
FROM sys.indexes
WHERE object_id = OBJECT_ID('Products') or object_id = OBJECT_ID('Categories') or object_id = OBJECT_ID('ProductCategories');

-- ������� ������
SELECT p.ProductName, c.CategoryName
FROM Products p
 LEFT JOIN ProductCategories pc ON p.ProductId = pc.ProductId
 LEFT JOIN Categories c ON pc.CategoryId = c.CategoryId
ORDER BY p.ProductName;
