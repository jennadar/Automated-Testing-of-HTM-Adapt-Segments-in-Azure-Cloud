using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloStudents
{
    internal class MyAlgorithm
    {
        public double Result  { get; set; } =0.0;

        public DateTime LastTime{ get; set; }

        private int callCounter = 0;

        public double Calculate(int i)
        {
            this.callCounter++;

            this.LastTime = DateTime.Now;   

            this.Result = this.Result + (double)i / 100;

            return Result;
        }

        #region Serialization
        public void Serialize(string file)
        {
            string data = $"{this.LastTime}|{this.callCounter}|{this.Result}";
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(data);
            }
        }

        public static MyAlgorithm Deserialize(string file)
        {
            using (StreamReader sw = new StreamReader(file))
            {
                string data = sw.ReadToEnd();
                var tokens = data.Split(new char[] { '|' });

                MyAlgorithm alg = new MyAlgorithm();

                DateTime lastTime;
                DateTime.TryParse(tokens[0], out lastTime);

                int counter;
                int.TryParse(tokens[1], out counter);

                // METHOBla.DoSomething(??, out res)

                double result;
                double.TryParse(tokens[2], out result);

                alg.callCounter = counter;
                alg.LastTime = lastTime;
                alg.Result = result;


                return alg;
            }
        }
        #endregion
    }
}
