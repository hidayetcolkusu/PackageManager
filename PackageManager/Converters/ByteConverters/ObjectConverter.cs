using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.ByteConverters
{ 
    public abstract class ObjectConverter<T> : IObjectConverter
    {
        public Type Type { get { return typeof(T); } } 
        public abstract byte ToByte(T value);
        public virtual byte[] ToByteArray(T value, int byteCount) { return null; }
    }

}
