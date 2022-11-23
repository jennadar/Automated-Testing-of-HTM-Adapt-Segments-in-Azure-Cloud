using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class MockInputProcessor : IInputProcessor
    {
        private ITracer? _tracer;
        public MockInputProcessor(ITracer? tracer = null)
        {
            _tracer = tracer;
        }

        public List<Animal> Process()
        {
            Console.WriteLine("Joke");

            this._tracer.Trace("Started processing animals.");

            var list = new List<Animal>();

            list.Add(new Animal(1, "fifi", "dog", 4));
            list.Add(new Animal(1, "fifi2", "dog", 5));

            return list;
        }
    }
}
