using PackageManager.Converters.ByteArrayConverters;
using PackageManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager
{
    public abstract class NetworkPackageGenerator
    { 
        private List<NetworkPackage> NetworkPackages { get; set; } = new List<NetworkPackage>();
        private List<dynamic> ByteArrayConverters { get; set; } = new List<dynamic>();
          
        public NetworkPackageGenerator()
        {
            ByteArrayConverters = new List<dynamic>();
            OnNetworkPackagesListBuilding();
            ByteArrayConverters = DefaultValues.ByteArrayConverters;
            OnByteArrayConvertersBuilding();
        }
         
        public abstract void OnNetworkPackagesListBuilding();

        public abstract dynamic OnCustomObjectConverting(dynamic converter, byte[] value);

        public abstract dynamic OnCustomObjectConverting(dynamic converter, byte value);

        public abstract void OnByteArrayConvertersBuilding();
         
        public void AddPackage(NetworkPackage networkPackage)
        {
            // yeni eklenen tipin özellikleri öncekiler ile farklı ise hata ver
            NetworkPackages.Add(networkPackage);
        }

        public void AddConverter<T>(T converter) where T : IByteConverter
        {
            ByteArrayConverters.Add(converter);
        }

        public void ChangeConverter<T>(T converter) where T : IByteConverter
        {
            dynamic oldConverter = ByteArrayConverters.Where(x => x.Type == converter.Type).FirstOrDefault();

            if (oldConverter != null)
                ByteArrayConverters.Remove(oldConverter);

            AddConverter(converter);
        }

        public void ClearConverters()
        {
            ByteArrayConverters.Clear();
        }

        public NetworkPackage Generate(byte[] bytes)
        {
            PackageHelpers packageHelpers = new PackageHelpers();

            NetworkPackage networkPackage = NetworkPackages.FirstOrDefault();

            if (networkPackage != null)
            {
                int rowIndex = networkPackage.Type.RowNumber - 1;

                if (bytes.Count() >= rowIndex)
                {
                    byte type = bytes[rowIndex];
                    networkPackage = NetworkPackages.Where(x => x.Type.Value == type).FirstOrDefault();
                    List<NetworkPackageValue> values = packageHelpers.GetNetworkPackageValues(networkPackage);
                    SetValues(networkPackage, values, bytes);
                } 
            }


            return networkPackage;
        }

        public NetworkPackage Generate(byte[] bytes, out bool isValidChecksum)
        {
            PackageHelpers packageHelpers = new PackageHelpers();

            NetworkPackage networkPackage = NetworkPackages.FirstOrDefault();

            if (networkPackage != null)
            {
                int rowIndex = networkPackage.Type.RowNumber - 1;

                if (bytes.Count() >= rowIndex)
                {
                    byte type = bytes[rowIndex];
                    networkPackage = NetworkPackages.Where(x => x.Type.Value == type).FirstOrDefault();
                    List<NetworkPackageValue> values = packageHelpers.GetNetworkPackageValues(networkPackage);
                    SetValues(networkPackage, values, bytes);
                }
            }

            isValidChecksum = networkPackage.CompareChecksum();

            return networkPackage;
        }

 
        private void SetValues(NetworkPackage networkPackage, List<NetworkPackageValue> values, byte[] bytes)
        {
            foreach (NetworkPackageValue value in values)
            {
                dynamic converter = GetConverter(value.Type);

                if (converter != null)
                {
                    if (value.ByteCount <= 1)
                        networkPackage[value.Name] = ConvertToByte(converter, bytes[value.RowNumber - 1]);
                    else
                        SetByteArrayValues(value, bytes, converter);
                } 
            } 
        }

        private void SetByteArrayValues(NetworkPackageValue value, byte[] bytes, dynamic converter)
        {
            byte[] range = bytes.ToList().GetRange(value.RowNumber - 1, value.ByteCount).ToArray();
            value.Value = ConvertToByteArray(converter, range);
            value.ByteArrayValue = range;
        }
          
        private dynamic GetConverter(Type type)
        {
            dynamic converter = null;

            foreach (var item in ByteArrayConverters)
            {
                IByteConverter obj = (IByteConverter)item;

                if (obj.Type == type)
                {
                    converter = item;
                    break;
                }
            }

            return converter;
        }
        
        private dynamic ConvertToByte(dynamic converter, byte value)
        {
            dynamic result = 0;

            if (!IsCustomConverter(converter))
            {
                result = converter.ToObject(value);
            }
            else
            {
                result = OnCustomObjectConverting(converter, value);
            } 

            return result;
        }

        private dynamic ConvertToByteArray(dynamic converter, byte[] value)
        {
            dynamic result = 0;

            if (!IsCustomConverter(converter))
            {
                result = converter.ToObject(value);
            }
            else
            {
                result = OnCustomObjectConverting(converter, value);
            }  

            return result;
        }

        private bool IsCustomConverter(dynamic converter)
        {
            bool result = false;

            try
            {
                string fullName = converter.Type.FullName;
            }
            catch 
            {
                result = true;
            }

            return result;
        }
    }
}
