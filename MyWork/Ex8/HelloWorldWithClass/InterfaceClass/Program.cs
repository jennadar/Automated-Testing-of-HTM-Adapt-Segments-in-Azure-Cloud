// See https://aka.ms/new-console-template for more information
using myLibrary;
using Triangle = myLibrary.Triangle;
using Rectangle = myLibrary.Rectangle;

int ch;
Console.WriteLine("1. Rectangle");
Console.WriteLine("2. Triangle");
Console.WriteLine("Enter your choice");
ch = Convert.ToInt32(Console.ReadLine());
if (ch == 1)
    {
        double w, h;
        Area r = new Rectangle();
        Console.WriteLine("Enter Width: ");
        w = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Height: ");
        h = Convert.ToDouble(Console.ReadLine());
        r.Area(w, h);
    }
    else if (ch == 2)
    {
        double w, h;
        Area t = new Triangle();
        Console.WriteLine("Enter Base: ");
        w = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Height: ");
        h = Convert.ToDouble(Console.ReadLine());
        t.Area(w, h);
    }
    else
    {
        Console.WriteLine("Invalid Choice");
    }