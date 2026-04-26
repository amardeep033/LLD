using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11_ISP
{
    public interface IBadStorage
    {
        //Looks clean, but different systems support different capabilities - read only archieve wont support upload or delete
        void Upload(string name, byte[] data);
        byte[] Download(string name);
        void Delete(string name);
        IEnumerable<string> ListDocuments();
        long GetStorageUsage();
    }
}