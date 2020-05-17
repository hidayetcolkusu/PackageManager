using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToDoubleConverter : ByteConverter<double>
    {
        public override double ToObject(byte value)
        {
            return Convert.ToDouble(value);
        }

        public override double ToObject(byte[] value)
        {
            return Convert.ToDouble(value[0]);
        }
    }
}
