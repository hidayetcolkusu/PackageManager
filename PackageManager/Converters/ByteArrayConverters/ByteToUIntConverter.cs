using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToUIntConverter : ByteConverter<uint>
    {
        public override uint ToObject(byte value)
        {
            return value;
        }

        public override uint ToObject(byte[] value)
        {
            return value[0];
        }
    }
}
