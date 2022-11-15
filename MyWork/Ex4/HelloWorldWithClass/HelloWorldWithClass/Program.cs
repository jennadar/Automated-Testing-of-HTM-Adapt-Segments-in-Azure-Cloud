// See https://aka.ms/new-console-template for more information
using myLibrary;


//Declare class object
var myObj = new myClass();

Console.WriteLine("Hello");

string input_1, input_2;
double num_1, num_2, output;
double[] inputs;

Console.WriteLine("\nType any nuumber: ");
input_1 = Console.ReadLine(); //string input from user
num_1 = Double.Parse(input_1); //Converting it to double

Console.WriteLine("\nType another nuumber: ");
input_2 = Console.ReadLine(); //string input from user
num_2 = Double.Parse(input_2); //Converting it to double

inputs = new double[] { num_1, num_2 };
output = myObj.sum(inputs);


Console.WriteLine("\n The summation between " + num_1 + " and " + num_2 + " is " + output);
Console.ReadLine();

