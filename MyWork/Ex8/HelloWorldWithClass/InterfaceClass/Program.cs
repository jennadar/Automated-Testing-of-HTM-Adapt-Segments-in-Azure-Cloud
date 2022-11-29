// See https://aka.ms/new-console-template for more information
using myLibrary;
using System.Drawing;
using Triangle = myLibrary.Triangle;
class Program
{
    static void Main(string[] arg)
    {
        int ch;
        Console.WriteLine("1. Rectangle");
        Console.WriteLine("2. Triangle");
        Console.WriteLine("Enter your choice");
        ch = Convert.ToInt32(Console.ReadLine());
        if (ch == 1)
        {
            double w, h;
            Rectangle r = new Rectangle();
            Console.WriteLine("Enter Width: ");
            w = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Height: ");
            h = Convert.ToDouble(Console.ReadLine());

        }
        else if (ch == 2)
        {
            double w, h;
            Triangle t = new Triangle();
            Console.WriteLine("Enter Base: ");
            w = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Height: ");
            h = Convert.ToDouble(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Invalid Choice");
        }
    }

}