using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class IntToByteConverter : ObjectConverter<int>
    { 
        public override byte ToByte(int value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(int value, int byteCount)
        {
            return new byte[] { 0, Convert.ToByte(value) };
        }
    }
}
