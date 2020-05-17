using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class DecimalToByteConverter : ObjectConverter<decimal>
    { 
        public override byte ToByte(decimal value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(decimal value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
