using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [
            new Square("White", 2),
            new Rectangle("Red", 4, 6),
            new Circle("Blue", 2)
        ];

        shapes.ForEach(shape =>
        {
            Console.WriteLine($"{shape} - Color: {shape.GetColor()} - Area: {shape.GetArea()}");
        });
    }
}