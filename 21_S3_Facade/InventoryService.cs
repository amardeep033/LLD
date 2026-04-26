using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18_B2_Facade
{
    public class InventoryService
    {
        public bool CheckStock(string product, int quantity)
        {
            Console.WriteLine($"[Inventory] Checking stock for {product}");
            return true;
        }

        public void ReserveStock(string product, int quantity)
        {
            Console.WriteLine($"[Inventory] Reserved {quantity} units of {product}");
        }

        public void ReleaseStock(string product, int quantity)
        {
            Console.WriteLine($"[Inventory] Released reserved stock for {product}");
        }
    }
}