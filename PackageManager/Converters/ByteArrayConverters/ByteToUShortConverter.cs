using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToUShortConverter : ByteConverter<ushort>
    {
        public override ushort ToObject(byte value)
        {
            return Convert.ToUInt16(value);
        }

        public override ushort ToObject(byte[] value)
        {
            if(value.Count() == 2)
                return BitConverter.ToUInt16(value, 0);
            else
                return Convert.ToUInt16(value[1]);
        }
    }
}
