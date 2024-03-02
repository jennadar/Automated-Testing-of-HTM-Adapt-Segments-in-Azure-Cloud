using System;
using System.Collections.Generic;
using System.Text;

namespace ClassInheritanceSample
{
    public class Encoder2 : EncoderBase
    {
        public Encoder2(string data) : base(data)
        {

        }

        public override string Encode()
        {
            string encoded = String.Empty;

            foreach (var chr in this.Data)
            {
                encoded += (char)(chr + (char)0x05);
            }

            return encoded;
        }
    }
}
