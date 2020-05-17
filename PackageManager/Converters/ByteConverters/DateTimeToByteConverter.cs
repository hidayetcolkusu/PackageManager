using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class DateTimeToByteConverter : ObjectConverter<DateTime>
    { 
        public override byte ToByte(DateTime value)
        {
            return Convert.ToByte(value);
        }
        public override byte[] ToByteArray(DateTime value, int byteCount)
        {
            return new byte[] { Convert.ToByte(value) };
        }
    }
}
