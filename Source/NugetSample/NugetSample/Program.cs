// See https://aka.ms/new-console-template for more information
using CsvHelper;
using NugetSample;

string filePath = "../../../data/record.csv";

Console.WriteLine("Hello");

Console.WriteLine($"Data has been read from {filePath}");
//Console.WriteLine("Data has been read from" + filePath);

var reader = new StreamReader(filePath);// dotnet Implementation

Console.WriteLine($"{reader.ReadLine()}");
var csv = new CsvReader(reader); //CSVHelper    

while (csv.Read())
{
    var record = new Foo
    {
        id = csv.GetField<int>("Id"),
        name = csv.GetField<string>("Name"),
        nationality =csv.GetField<string>("Nationality")
    };
    //records.Add(record);
    Console.WriteLine($"Id: {record.id}, Name: {record.name}, Nationality: {record.nationality}");
}
Console.ReadLine();

