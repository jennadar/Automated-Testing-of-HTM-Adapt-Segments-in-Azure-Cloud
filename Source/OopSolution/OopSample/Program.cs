using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OopSample
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            var svcLoc = RegisterServices();
          
            ITracer tracer = svcLoc.GetService<ITracer>()!;
            tracer.Trace("Hello best students");

            IInputProcessor proc = svcLoc.GetService<IInputProcessor>()!;
            var animals = proc.Process();
            tracer.Trace("Hello sleepy students. I have created lisyt of animals. :)");

            IAnimalPrinter printer = svcLoc.GetService<IAnimalPrinter>()!;
            printer.Print(animals);
            tracer.Trace("Finally done :)");
        }

        static void MainWithoutDI(string[] args)
        {
            IInputProcessor proc = new MockInputProcessor(new MyDebugWindowsTracer());
            var animals = proc.Process();

            SimpleAnimalPrinter printer = new SimpleAnimalPrinter();
            printer.Print(animals);
        }

        private static IServiceProvider RegisterServices(string[]? args = null)
        {
            var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services
                .AddSingleton(typeof(IInputProcessor), typeof(MockInputProcessor))
                .AddSingleton(typeof(IAnimalPrinter), typeof(FileAnimalPrinter))
                .AddSingleton(typeof(ITracer), typeof(MyFileTracer))
                )
            .Build();

            var s = host.Services.GetService<IInputProcessor>();
            return host.Services;
        }
    }
}