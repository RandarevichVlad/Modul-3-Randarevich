using System;

// Базовый класс "Фигура"
class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

// Производный класс "Круг"
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// Производный класс "Прямоугольник"
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// Производный класс "Треугольник"
class Triangle : Shape
{
    public double BaseLength { get; set; }
    public double Height { get; set; }

    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * BaseLength * Height;
    }
}

class Program
{
    delegate double CalculateAreaDelegate();

    static void Main(string[] args)
    {
        Console.WriteLine("Выберите фигуру (1 - Круг, 2 - Прямоугольник, 3 - Треугольник):");
        int choice = int.Parse(Console.ReadLine());

        Shape shape = null;

        switch (choice)
        {
            case 1:
                Console.Write("Введите радиус круга: ");
                double radius = double.Parse(Console.ReadLine());
                shape = new Circle(radius);
                break;
            case 2:
                Console.Write("Введите ширину прямоугольника: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("Введите высоту прямоугольника: ");
                double height = double.Parse(Console.ReadLine());
                shape = new Rectangle(width, height);
                break;
            case 3:
                Console.Write("Введите длину основания треугольника: ");
                double baseLength = double.Parse(Console.ReadLine());
                Console.Write("Введите высоту треугольника: ");
                double triangleHeight = double.Parse(Console.ReadLine());
                shape = new Triangle(baseLength, triangleHeight);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        if (shape != null)
        {
            CalculateAreaDelegate shapeDelegate = shape.CalculateArea;
            Console.WriteLine("Площадь фигуры: " + shapeDelegate());
        }

        Console.ReadLine();
    }
}
