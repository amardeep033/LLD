using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11_ISP
{
    public class GoodArchieve : IDocumentReader, IStorageMonitor
    {

        public byte[] Download(string name)
        {
            return new byte[0];
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