using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyLibrary
{
    public class SampleSerializer
    {
        public void Serialize(object obj, string file)
        {
            string str = JsonSerializer.Serialize(obj);
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(str);
            }
        }

        public T Deserialize<T>(string file)
        {
            using (StreamReader sw = new StreamReader(file))
            {
                string data = sw.ReadToEnd();
                T obj = JsonSerializer.Deserialize<T>(data);
                return obj;
            }
        }
    }
}
