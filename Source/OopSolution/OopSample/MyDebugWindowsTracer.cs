using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopSample
{
    public class MyDebugWindowsTracer : ITracer
    {
        public void Trace(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
