using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Converters.Checksum
{
    internal class ChecksumCalculator : BaseChecksumCalculator
    {
        private ChecksumManager.ChecksumCalculator _checksumCalculator;

        public ChecksumCalculator()
        {
            _checksumCalculator = new ChecksumManager.ChecksumCalculator();
        }

        public override ushort Calculate(byte[] bytes)
        {
            return _checksumCalculator.Calculate(bytes);
        }

        public override bool Compare(byte[] bytes, int startIndex)
        {
            return _checksumCalculator.Compare(bytes, startIndex);
        }

        public override bool Compare(byte[] bytes, ushort checksum)
        {
            return _checksumCalculator.Compare(bytes, checksum);
        }
    }
}
