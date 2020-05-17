using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToObjectConverter : ByteConverter<object>
    {
        public override object ToObject(byte value)
        {
            return value;
        }

        public override object ToObject(byte[] value)
        {
            return value;
        }
    }
}
