using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToStringConverter : ByteConverter<string>
    {
        public override string ToObject(byte value)
        {
            return value.ToString();
        }

        public override string ToObject(byte[] value)
        {
            return value[0].ToString();
        }
    }
}
