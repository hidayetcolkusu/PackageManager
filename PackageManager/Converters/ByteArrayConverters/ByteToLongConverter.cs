using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToLongConverter : ByteConverter<long>
    {
        public override long ToObject(byte value)
        {
            return Convert.ToInt64(value);
        }

        public override long ToObject(byte[] value)
        {
            return Convert.ToInt64(value[0]);
        }
    }
}
