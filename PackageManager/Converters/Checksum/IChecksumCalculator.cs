using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.Checksum
{
    public interface IChecksumCalculator
    {
        ushort Calculate(byte[] bytes);
        bool Compare(byte[] bytes, int startIndex);
        bool Compare(byte[] bytes, ushort checksum);
    }
}
