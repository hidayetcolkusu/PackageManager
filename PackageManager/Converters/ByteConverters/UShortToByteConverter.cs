using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class UShortToByteConverter : ObjectConverter<ushort>
    { 
        public override byte ToByte(ushort value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(ushort value, int byteCount)
        {
            if(byteCount == 2)
                return BitConverter.GetBytes(value);
            else
                return new byte[] { Convert.ToByte(value), 0 };
        }
    }
}
