using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11_ISP
{
    //group common together -- dont over segregate
    public interface IDocumentReader
    {
        byte[] Download(string name);
        IEnumerable<string> ListDocuments();
    }

    public interface IDocumentWriter
    {
        void Upload(string name, byte[] data);
        void Delete(string name);
    }

    public interface IStorageMonitor
    {
        long GetStorageUsage();
    }
}