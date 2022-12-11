// See https://aka.ms/new-console-template for more information
using ConfigSample;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World with Configuration!");

var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile("appsettings2.json", optional: true, reloadOnChange: true)
          .AddCommandLine(args)
          .AddEnvironmentVariables();

IConfigurationRoot configuration = builder.Build();

// MySettings allSettings = new MySettings();
var mySettings = configuration.GetSection("mysettings").Get<MySettings[]>();
// configuration.Bind(allSettings);

//var id = configuration["Id"];
//var name = configuration["Name"];

foreach (var mySetting in mySettings) {
    Console.WriteLine($"Id = {mySetting.id}");
    Console.WriteLine($"Name = {mySetting.name}");
    Console.WriteLine($"Age = {mySetting.age}");
    Console.WriteLine($"Country = {mySetting.country}");
    Console.WriteLine($"Tel = {mySetting.tel}");
    Console.WriteLine($"Email = {mySetting.email}");
}


Console.ReadLine();
