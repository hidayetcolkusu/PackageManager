using PackageManager.Converters.ByteArrayConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Helpers
{
    public class PackageHelpers
    { 
        public List<NetworkPackageValue> GetNetworkPackageValues(NetworkPackage networkPackage)
        {
            List<NetworkPackageValue> networkPackageValues = new List<NetworkPackageValue>();

            var properties = GetPropertyInfos(networkPackage);

            foreach (var proprty in properties)
            {
                if (IsValidProp(proprty))
                    networkPackageValues.Add(GetNetworkPackageValue(networkPackage, proprty.Name));
            }

            return networkPackageValues;
        }

        private NetworkPackageValue GetNetworkPackageValue(NetworkPackage networkPackage, string propName)
        {
            return (NetworkPackageValue)networkPackage.GetType().GetProperty(propName).GetValue(networkPackage, null);
        }

        private bool IsValidProp(PropertyInfo proprty)
        {
            if (proprty.PropertyType != null)
                if (proprty.PropertyType.Name != null)
                    if (proprty.PropertyType.Name == "NetworkPackageValue")
                        return true;

            return false;
        }

        private List<PropertyInfo> GetPropertyInfos(NetworkPackage networkPackage)
        {
            return networkPackage.GetType().GetProperties().ToList();
        } 
    }
}
