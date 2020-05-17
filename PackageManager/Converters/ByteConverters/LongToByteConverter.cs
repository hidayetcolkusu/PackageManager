using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class LongToByteConverter : ObjectConverter<long>
    { 
        public override byte ToByte(long value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(long value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
