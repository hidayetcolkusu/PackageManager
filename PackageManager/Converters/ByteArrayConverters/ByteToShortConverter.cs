using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToShortConverter : ByteConverter<short>
    {
        public override short ToObject(byte value)
        {
            return (short)value;
        }

        public override short ToObject(byte[] value)
        {
            return (short)value[0];
        }
    }
}
