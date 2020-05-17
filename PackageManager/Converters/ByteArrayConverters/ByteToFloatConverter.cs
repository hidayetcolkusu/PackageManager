using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToFloatConverter : ByteConverter<float>
    {
        public override float ToObject(byte value)
        {
            return (float)Convert.ToDouble(value);
        }

        public override float ToObject(byte[] value)
        {
            return (float)Convert.ToDouble(value[0]);
        }
    }
}
