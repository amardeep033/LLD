using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11_ISP
{
    public class BadArchieve : IBadStorage
    {
        public void Upload(string name, byte[] data)
        {
            //forced to impl
            throw new NotSupportedException();
        }

        public byte[] Download(string name)
        {
            return new byte[0];
        }

        public void Delete(string name)
        {
            //forced to impl
            throw new NotSupportedException();
        }

        public IEnumerable<string> ListDocuments()
        {
            return new List<string>();
        }

        public long GetStorageUsage()
        {
            return 0;
        }
    }
}