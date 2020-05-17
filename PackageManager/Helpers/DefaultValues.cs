using PackageManager.Converters.ByteArrayConverters;
using PackageManager.Converters.ByteConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Helpers
{
    internal class DefaultValues
    { 
        public static NetworkPackageValue Stx
        {
            get
            {
                return new NetworkPackageValue()
                {
                    Name      = "Stx"
                   ,RowNumber = 1
                   ,Value     = (byte)2
                   ,ByteCount = 1
                }; 
            }
        }

        public static NetworkPackageValue Lenght
        {
            get
            {
                return new NetworkPackageValue()
                {
                    Name      = "Lenght"
                   ,RowNumber = 2 
                   ,Value     = (byte)3
                   ,ByteCount = 1
                };
            }
        }

        public static NetworkPackageValue Type
        {
            get
            {
               return new NetworkPackageValue()
               {
                   Name      = "Type"
                  ,RowNumber = 3
                  ,Value     = (byte)3
                  ,ByteCount = 1
               };
            }
        }

        public static NetworkPackageValue Checksum
        {
            get
            {
                return new NetworkPackageValue()
                {
                    Name      = "Checksum"
                   ,RowNumber = 4  
                   ,Value     = (ushort)0
                   ,ByteCount = 2
                };
            }
        }

        public static NetworkPackageValue Etx
        {
            get
            {
               return new NetworkPackageValue()
                {
                    Name      = "Etx"
                   ,RowNumber = 5
                   ,Value     = (byte)3
                   ,ByteCount = 1
                };
            }
        }

        public static List<dynamic> ByteConverters
        {
            get
            {
                List<dynamic> byteConverters = new List<dynamic>();

                byteConverters.Add(new BoolToByteConverter());
                byteConverters.Add(new PackageManager.Converters.ByteConverters.ByteToByteConverter());
                byteConverters.Add(new CharToByteConverter());
                byteConverters.Add(new DateTimeToByteConverter());
                byteConverters.Add(new DecimalToByteConverter());
                byteConverters.Add(new DoubleToByteConverter());
                byteConverters.Add(new FloatToByteConverter());
                byteConverters.Add(new IntToByteConverter());
                byteConverters.Add(new LongToByteConverter());
                byteConverters.Add(new ObjectToByteConverter());
                byteConverters.Add(new SByteToByteConverter());
                byteConverters.Add(new ShortToByteConverter());
                byteConverters.Add(new StringToByteConverter());
                byteConverters.Add(new UIntToByteConverter());
                byteConverters.Add(new ULongToByteConverter());
                byteConverters.Add(new UShortToByteConverter());

                return byteConverters;
            }
        }

        public static List<dynamic> ByteArrayConverters
        {
            get
            {
                List<dynamic> byteArrayConverters = new List<dynamic>();

                byteArrayConverters.Add(new ByteToBoolConverter());
                byteArrayConverters.Add(new PackageManager.Converters.ByteArrayConverters.ByteToByteConverter());
                byteArrayConverters.Add(new ByteToCharConverter());
                byteArrayConverters.Add(new ByteToDateTimeConverter());
                byteArrayConverters.Add(new ByteToDecimalConverter());
                byteArrayConverters.Add(new ByteToDoubleConverter());
                byteArrayConverters.Add(new ByteToFloatConverter());
                byteArrayConverters.Add(new ByteToIntConverter());
                byteArrayConverters.Add(new ByteToLongConverter());
                byteArrayConverters.Add(new ByteToObjectConverter());
                byteArrayConverters.Add(new ByteToSByteConverter());
                byteArrayConverters.Add(new ByteToShortConverter());
                byteArrayConverters.Add(new ByteToStringConverter());
                byteArrayConverters.Add(new ByteToUIntConverter());
                byteArrayConverters.Add(new ByteToULongConverter());
                byteArrayConverters.Add(new ByteToUShortConverter());

                return byteArrayConverters;
            }
        }         

    }
}
