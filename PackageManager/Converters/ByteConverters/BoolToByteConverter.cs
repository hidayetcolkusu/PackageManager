using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class BoolToByteConverter : ObjectConverter<bool>
    { 
        public override byte ToByte(bool value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(bool value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
