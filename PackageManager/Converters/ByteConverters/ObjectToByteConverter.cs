using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class ObjectToByteConverter : ObjectConverter<object>
    {  
        public override byte ToByte(object value)
        {
            return 0;
        }
        public override byte[] ToByteArray(object value, int byteCount)
        {
            return new byte[] { 0 };
        }
    }
}
