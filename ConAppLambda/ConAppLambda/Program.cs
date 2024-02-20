using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppLambda
{
    class Program
    {
        //delegate double MathDel(double num1, double num2);
        //static void Main(string[] args)
        //{
        //    MathDel add = (n1,n2) => { return (n1 + n2); };
        //    MathDel div = (n1,n2) => (n1/n2);
        //    MathDel multi = (n1,n2) => (n1*n2);
        //    MathDel sub = (n1,n2) => (n1-n2);

        //    Console.WriteLine("Add Result : " + add(12.56,11.44));
        //    Console.WriteLine("Multiply Result : " + multi(12.56,11.44));
        //    Console.WriteLine("Division Result : " + div(12.56,11.44));
        //    Console.WriteLine("Substraction Result : " + sub(12.56,11.44));
        //    Console.Read();
        //}

        delegate double CubeDel(double number);
        public static void Main()
        {
            CubeDel cubeDel = (num) => (Math.Pow(num,3));
            Console.WriteLine("Enter the number: ");
            double number = double.Parse(Console.ReadLine());
            
            Console.WriteLine($"Cube of Number({number}) is : " + cubeDel(number));
            Console.ReadLine();
        }
    }
}
