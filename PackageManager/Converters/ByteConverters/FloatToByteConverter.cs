using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class FloatToByteConverter : ObjectConverter<float>
    {  
        public override byte ToByte(float value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(float value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
