using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class SByteToByteConverter : ObjectConverter<sbyte>
    {  
        public override byte ToByte(sbyte value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(sbyte value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
