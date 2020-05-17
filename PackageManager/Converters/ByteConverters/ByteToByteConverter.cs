using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class ByteToByteConverter : ObjectConverter<byte>
    { 
        public override byte ToByte(byte value)
        {
            return value;
        }
        public override byte[] ToByteArray(byte value, int byteCount)
        {
            return new byte[] { value };
        }
    }
}
