using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.Checksum
{
    public abstract class BaseChecksumCalculator : IChecksumCalculator
    {
        public abstract ushort Calculate(byte[] bytes);
        public abstract bool Compare(byte[] bytes, int startIndex);
        public abstract bool Compare(byte[] bytes, ushort checksum);
    }
}
