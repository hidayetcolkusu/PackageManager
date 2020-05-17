using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class DoubleToByteConverter : ObjectConverter<double>
    { 
        public override byte ToByte(double value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(double value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
