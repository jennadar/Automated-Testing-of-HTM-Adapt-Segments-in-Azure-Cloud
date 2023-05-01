// See https://aka.ms/new-console-template for more information



using Microsoft.Extensions.Configuration;
using ReadingConfiguration;

Console.WriteLine("Hello, World with configuration");

var builder = new ConfigurationBuilder()

.SetBasePath(Directory.GetCurrentDirectory())  // call the method
.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
.AddCommandLine(args)
.AddEnvironmentVariables();


IConfigurationRoot configuration = builder.Build();

// Data directly retrieved as a AppSettings instance.
// Implicit declaration
var settings = configuration.Get<appsettings>();
Console.WriteLine($"Id = {settings.Id}");
Console.WriteLine($"Name = {settings.Name}");
Console.WriteLine($"Age = {settings.Age}");
Console.WriteLine($"Country = {settings.Country}");
Console.WriteLine($"Email = {settings.Email}");



Console.ReadLine();