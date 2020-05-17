using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToULongConverter : ByteConverter<ulong>
    {
        public override ulong ToObject(byte value)
        {
            return value;
        }

        public override ulong ToObject(byte[] value)
        {
            return value[0];
        }
    }
}
