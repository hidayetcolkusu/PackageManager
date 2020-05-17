using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToCharConverter : ByteConverter<char>
    {
        public override char ToObject(byte value)
        {
            return (char)value;
        }

        public override char ToObject(byte[] value)
        {
            return (char)value[0]; 
        }
    }
}
