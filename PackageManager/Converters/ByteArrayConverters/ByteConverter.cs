using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteArrayConverters
{  
    public abstract class ByteConverter<T> : IByteConverter
    {
        public Type Type { get { return typeof(T); } } 
        public abstract T ToObject(byte value);
        public virtual T ToObject(byte[] value) { throw new Exception(""); }
    }
}
