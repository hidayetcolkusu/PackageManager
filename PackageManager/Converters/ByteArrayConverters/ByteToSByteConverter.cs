using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToSByteConverter : ByteConverter<sbyte>
    {
        public override sbyte ToObject(byte value)
        {
            return (sbyte)value;
        }

        public override sbyte ToObject(byte[] value)
        {
            return (sbyte)value[0];
        }
    }
}
