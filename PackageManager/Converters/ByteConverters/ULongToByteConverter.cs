using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class ULongToByteConverter : ObjectConverter<ulong>
    { 
        public override byte ToByte(ulong value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(ulong value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
