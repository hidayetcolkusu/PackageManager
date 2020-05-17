
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{
    internal class StringToByteConverter : ObjectConverter<string>
    { 
        public override byte ToByte(string value)
        { 
            return 0;
        } 
        public override byte[] ToByteArray(string value, int byteCount)
        {
            return new byte[] { 0 };
        }
    }
}
 