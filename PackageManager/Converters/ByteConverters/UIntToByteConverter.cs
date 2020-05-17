using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class UIntToByteConverter : ObjectConverter<uint>
    { 
        public override byte ToByte(uint value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(uint value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
