using System;
using System.Collections.Generic;
using System.Text;

namespace ClassInheritanceSample
{
    public class Encoder1 : EncoderBase
    {
        public Encoder1(string data) : base(data)
        {

        }

        public override string Encode()
        {
            string encoded = String.Empty;

            foreach (var chr in this.Data)
            {
                encoded += (char)(chr + (char)0x01);
            }

            return encoded;
        }
    }
}
