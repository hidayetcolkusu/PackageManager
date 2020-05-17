using PackageManager.Converters;
using PackageManager.Converters.ByteArrayConverters;
using PackageManager.Converters.ByteConverters;
using PackageManager.Converters.Checksum;
using PackageManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager
{
    public class NetworkPackage
    {
        public NetworkPackageValue Stx                { get; set; }
        public NetworkPackageValue Lenght             { get; set; }
        public NetworkPackageValue Type               { get; set; }
        public NetworkPackageValue Checksum           { get; set; }
        public NetworkPackageValue Etx                { get; set; }
        internal List<dynamic> ByteConverters         { get; set; } = new List<dynamic>(); 
        private dynamic ChecksumCalculator            { get; set; }
        public dynamic this[string paramName]
        {
            get
            {
                
                return GetValueFromParam(paramName);
            }
            set
            {
                SetValueFromParam(paramName, value);
            }
        }
                       
        public NetworkPackage()
        {
            ChecksumCalculator = new ChecksumCalculator();
            GetDefaultPackageValues();
            OnPackageValuesBuilding();
            OnPackageConvertersBuilding(); 
        }

        public virtual void OnPackageValuesBuilding() { }

        public virtual void OnPackageConvertersBuilding()
        {
            ByteConverters = DefaultValues.ByteConverters;
        }

        public virtual byte OnCustomObjectConverting(dynamic converter, dynamic value)
        {
            throw new Exception("");
        }

        public virtual byte[] OnCustomObjectConverting(dynamic converter, dynamic value, int byteCount)
        {
            throw new Exception("");
        }
         
        public void AddConverter<T>(T converter) where T : IObjectConverter
        {
            ByteConverters.Add(converter);
        }

        public void ChangeConverter<T>(T converter) where T : IObjectConverter
        {
            dynamic oldConverter = ByteConverters.Where(x => x.Type == converter.Type).FirstOrDefault();

            if(oldConverter != null)
                ByteConverters.Remove(oldConverter);

            AddConverter(converter);
        }

        public void ChangeChecksumCalculator<T>(T calculator) where T : IChecksumCalculator
        {
            ChecksumCalculator = calculator;
        }

        public void ClearConverters()
        {
            ByteConverters.Clear();
        }

        private void GetDefaultPackageValues()
        {
            Stx      = DefaultValues.Stx;
            Lenght   = DefaultValues.Lenght;
            Type     = DefaultValues.Type;
            Checksum = DefaultValues.Checksum;
            Etx      = DefaultValues.Etx;
        }

        public byte[] GenerateByteArray()
        {
            List<byte> bytes = new List<byte>();
              
            List<NetworkPackageValue> packageValues = GetNetworkPackageValues();

            bytes = GetBytesWithChecksum(packageValues);

            return bytes.ToArray();
        } 

        public bool CompareChecksum()
        {
            ushort checksum = Checksum.Value;

            List<NetworkPackageValue> packageValues = GetNetworkPackageValues();

            byte[] bytes = GetBytesWithoutChecksum(packageValues).ToArray();

            return ChecksumCalculator.Compare(bytes, checksum);
        }

        public bool CompareChecksum(ushort checksum)
        {
            List<NetworkPackageValue> packageValues = GetNetworkPackageValues();
             
            byte[] bytes = GetBytesWithoutChecksum(packageValues).ToArray();

            return ChecksumCalculator.Compare(bytes, checksum);
        }

        private List<byte> GetBytesWithChecksum(List<NetworkPackageValue> packageValues)
        {
            List<byte> bytes = new List<byte>();

            foreach (var packageValue in packageValues)
            {
                if (packageValue.ByteCount > 1)
                    bytes.AddRange(packageValue.ByteArrayValue);
                else
                    bytes.Add(packageValue.ByteValue);
            }

            return bytes;
        }


        private List<byte> GetBytesWithoutChecksum(List<NetworkPackageValue> packageValues)
        {
            List<byte> bytes = new List<byte>();

            foreach (var packageValue in packageValues)
            {
                if (packageValue.Name != "Checksum")
                {
                    if (packageValue.ByteCount > 1)
                        bytes.AddRange(packageValue.ByteArrayValue);
                    else
                        bytes.Add(packageValue.ByteValue);
                }
            }

            return bytes;
        }

        private List<byte> SetChecksum(byte[] bytes)
        {
            List<byte> byteList = bytes.ToList();

            ushort checksum = ChecksumCalculator.Calculate(bytes.ToArray());
            dynamic instance = Activator.CreateInstance(this.GetType());
            instance["Checksum"] = checksum;
            byte[] checksumBytes = instance.Checksum.ByteArrayValue;
            byteList.InsertRange(instance.Checksum.RowNumber - 1, checksumBytes);

            return byteList;
        }
 
        private void SetValueFromParam(string paramName, dynamic value)
        {
            var param = GetPropertyInfo(paramName);

            if (param != null)
            {
                NetworkPackageValue paramValue = GetNetworkPackageValue(paramName);
                paramValue.Value = value;
                SetByteValues(paramValue, value);
            }
        }

        private void SetByteValues(NetworkPackageValue paramValue, dynamic value)
        {
            dynamic converter = GetConverter(value.GetType());

            if (converter != null)
            {
                int byteCount = paramValue.ByteCount;

                if (byteCount <= 1)
                    paramValue.ByteValue = ConverToByte(converter, value);
                else
                    paramValue.ByteArrayValue = ConverToByteArray(converter, value, byteCount);
            }
        }

        private dynamic GetValueFromParam(string paramName)
        {
            dynamic value = null;

            var param = GetPropertyInfo(paramName);

            if (param != null)
                value = GetNetworkPackageValue(paramName);

            return value;
        }

        private List<NetworkPackageValue> GetNetworkPackageValues()
        {
            List<NetworkPackageValue> packageValues = new List<NetworkPackageValue>();

            List<string> paramaters = GetPropertiesNames();

            foreach (var param in paramaters)
            {
                NetworkPackageValue value = GetNetworkPackageValue(param);
                packageValues.Add(value);
            }

            packageValues = packageValues.OrderBy(x => x.RowNumber).ToList();

            return packageValues;
        }

        private PropertyInfo GetPropertyInfo(string paramName)
        {
            return this.GetType().GetProperties().Where(x => x.PropertyType == typeof(NetworkPackageValue) && x.Name == paramName).FirstOrDefault();
        }

        private NetworkPackageValue GetNetworkPackageValue(string paramName)
        {
            return (NetworkPackageValue)this.GetType().GetProperty(paramName).GetValue(this, null);
        }

        private List<string> GetPropertiesNames()
        {
            return this.GetType().GetProperties().Where(x => x.PropertyType == typeof(NetworkPackageValue)).Select(x => x.Name).ToList();
        }
         
        private dynamic GetConverter(Type type)
        {
            dynamic converter = null;

            foreach (var item in ByteConverters)
            {
                IObjectConverter obj = (IObjectConverter)item;

                if (obj.Type == type)
                {
                    converter = item; 
                    break;
                }
            }

            return converter;
        }
        
        private byte ConverToByte(dynamic converter, dynamic value)
        {
            byte result = 0;
              
            if (!IsCustomConverter(converter, value))
            {
                result = converter.ToByte(value);
            }
            else
            {
                result = OnCustomObjectConverting(converter, value);
            }

            return result;
        }

        private byte[] ConverToByteArray(dynamic converter, dynamic value, int byteCount)
        {
            byte[] result = null;

            if (!IsCustomConverter(converter, value))
            {
                result = converter.ToByteArray(value, byteCount);
            }
            else
            {
                result = OnCustomObjectConverting(converter, value, byteCount);
            } 

            return result;
        }

        private bool IsCustomConverter(dynamic converter, dynamic value)
        {
            bool result = false;

            try
            {
                string fullName = converter.Type.FullName;
                Type type = value.GetType();
            }
            catch
            {
                result = true;
            }

            return result;
        }


    }
}
