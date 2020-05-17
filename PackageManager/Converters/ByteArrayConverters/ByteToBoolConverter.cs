using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{
    internal class ByteToBoolConverter : ByteConverter<bool>
    {
        public override bool ToObject(byte value)
        {
            return true;
        }

        public override bool ToObject(byte[] value)
        {
            return true;
        } 
    }
}
