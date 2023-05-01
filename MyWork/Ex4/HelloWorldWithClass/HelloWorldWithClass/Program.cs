// See https://aka.ms/new-console-template for more information
using myLibrary;
using mySecondLibrary;


//Declare class object
var myObj = new myClass();
var myObj_fib = new myClassFib();

Console.WriteLine("Hello");

string input_1, input_2;
double num_1, num_2, output;
double[] inputs;

Console.WriteLine("\nType any n umber: ");
input_1 = Console.ReadLine(); //string input from user
num_1 = Double.Parse(input_1); //Converting it to double

Console.WriteLine("\nType another nuumber: ");
input_2 = Console.ReadLine(); //string input from user
num_2 = Double.Parse(input_2); //Converting it to double

inputs = new double[] { num_1, num_2 };
output = myObj.sum(inputs);


Console.WriteLine("\n The summation between " + num_1 + " and " + num_2 + " is " + output);
Console.WriteLine("-------------------------------------------------------------------");

Console.WriteLine("\nEnter the number of elements: ");
string input_fib;
int num_fib, output_fib;
input_fib = Console.ReadLine(); //string input from user
num_fib = int.Parse(input_fib); //Converting it to int
Console.WriteLine("\n The Fibonacci series of " + num_fib + " are " );
output_fib = myObj_fib.fibonacci(num_fib);
Console.WriteLine("-------------------------------------------------------------------");
Console.ReadLine();



