using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToDateTimeConverter : ByteConverter<DateTime>
    {
        public override DateTime ToObject(byte value)
        {
            return DateTime.Now;
        }

        public override DateTime ToObject(byte[] value)
        {
            return DateTime.Now;
        }
    }
}
