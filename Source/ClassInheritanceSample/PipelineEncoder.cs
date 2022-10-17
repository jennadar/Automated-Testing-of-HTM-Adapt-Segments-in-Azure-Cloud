using System;
using System.Collections.Generic;
using System.Text;

namespace ClassInheritanceSample
{
    public class PipelineEncoder : Encoder2
    {
        public PipelineEncoder(string data) : base(data)
        {

        }

        public override string Encode()
        {
            string encoded = String.Empty;

            // Note calling of base.Encode here. This invokes base encoder
            // and then we encode data encoded by base encoder.
            foreach (var chr in base.Encode())
            {
                encoded += (char)(chr + (char)0x05);
            }

            return encoded;
        }
    }
}
