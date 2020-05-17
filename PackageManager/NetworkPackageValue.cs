using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager
{ 
    public class NetworkPackageValue 
    { 
        public string Name            { get; set; }
        public int RowNumber          { get; set; }
        public dynamic Value          { get; set; }
        public byte ByteValue         { get; set; }
        public byte[] ByteArrayValue  { get; internal set; } = new byte[0];
        public int ByteCount          { get; set; } = 1;
        public Type Type      
        { 
            get 
            {
                if (Value != null)
                    return Value.GetType();
                else
                    return null;
            } 
        }

    }
    
}
