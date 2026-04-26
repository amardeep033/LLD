using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Coupling
{
    public interface IGoodNotification
    {
        //abstract method is just the signature of the method without implementation -- it will be implemented by the classes that implement this interface
        //whereas abstract class can have both abstract and non-abstract methods -- it can have implementation for some methods and not for others
        void SendNotification(string to, string subject, string body);
    }
}