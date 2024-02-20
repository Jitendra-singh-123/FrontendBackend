using System;
using ShapeAreaLib;

namespace RealAlgebra
{
    static class Extensionimp
    {
        public static string Message(this Rectangle rec, string msg)
        {
            return msg;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter One option for calculating area and perimeter");
            Console.WriteLine("1.Rectangle\n2.Square\n3.Circle\n4.Triangle");
            int opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1:
                    Console.WriteLine("Enter the Length of Rectangle");
                    double l = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Breadth of Rectangle");
                    double b = double.Parse(Console.ReadLine());
                    Rectangle rectangle = new Rectangle();
                    Console.WriteLine(rectangle.Message("Rectangle"));
                    Console.WriteLine("Area of Rectangle is : " + rectangle.Area(l,b));
                    Console.WriteLine("Perimeter of Rectangle is : " + rectangle.Perimeter(l,b));
                    break;
                case 2:
                    Console.WriteLine("Enter the Side of Square");
                    double s = double.Parse(Console.ReadLine());
                    Square square = new Square();

                    Console.WriteLine("Area of Square is : " + square.Area(s));
                    Console.WriteLine("Perimeter of Square is : " + square.Perimeter(s));
                    break;
                case 3:
                    Console.WriteLine("Enter the Radius of Circle");
                    double r = double.Parse(Console.ReadLine());
                    
                    Circle circle = new Circle();
                    Console.WriteLine("Area of Circe is : " + circle.Area(r));
                    Console.WriteLine("Circumference of Circle is : " + circle.Perimeter(r));
                    break;
                case 4:
                    Console.WriteLine("Enter the Height of Triangle");
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Base of Triangle");
                    double B = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Side2 of Triangle");
                    double s2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Side3 of Triangle");
                    double s3 = double.Parse(Console.ReadLine());
                    Triangle triangle = new Triangle();
                    Console.WriteLine("Area of Triangle is : " + triangle.Area(B,h));
                    Console.WriteLine("Perimeter of Rectangle is : " + triangle.Perimeter(B,s2,s3));
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            Console.ReadLine();
        }
    }
}
