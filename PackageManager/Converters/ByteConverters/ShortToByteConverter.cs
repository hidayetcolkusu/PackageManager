using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class ShortToByteConverter : ObjectConverter<short>
    { 
        public override byte ToByte(short value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(short value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
