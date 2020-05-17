using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToByteConverter : ByteConverter<byte>
    {
        public override byte ToObject(byte value)
        {
            return value;
        }

        public override byte ToObject(byte[] value)
        {
            return value[0];
        }
    }
}
