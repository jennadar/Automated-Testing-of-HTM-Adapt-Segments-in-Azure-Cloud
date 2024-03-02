using System;
using System.Collections.Generic;
using System.Text;

namespace ClassInheritanceSample
{
    public class EncoderBase
    {
        protected string Data { get; private set; }

        public EncoderBase(string data)
        {
            this.Data = data;
        }

        /// <summary>
        /// No encoding by base class.
        /// </summary>
        /// <returns></returns>
        public virtual string Encode()
        {
            return this.Data;
        }
    }
}
