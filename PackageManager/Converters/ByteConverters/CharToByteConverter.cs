using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class CharToByteConverter : ObjectConverter<char>
    { 
        public override byte ToByte(char value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(char value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
