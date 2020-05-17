using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToDecimalConverter : ByteConverter<decimal>
    {
        public override decimal ToObject(byte value)
        {
            return Convert.ToDecimal(value);
        }

        public override decimal ToObject(byte[] value)
        {
            return Convert.ToDecimal(value[0]);
        }
    }
}
