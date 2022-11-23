using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class MyFileTracer : ITracer
    {
        private string _fileName = "Trace.txt";
        public void Trace(string msg)
        {
            using (StreamWriter sw = new StreamWriter(_fileName, true))
            {
                sw.WriteLine(msg);
            }
        }
    }
}
