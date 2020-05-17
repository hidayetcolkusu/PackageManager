using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToIntConverter : ByteConverter<int>
    {
        public override int ToObject(byte value)
        {
            return Convert.ToInt32(value);
        }

        public override int ToObject(byte[] value)
        {
            return Convert.ToInt32(value[0]);
        }
    }
}
