// ISP — Interface Segregation Principle
// Fat interface forces implementation → class can't honour a method → throws or fakes it → substitution breaks → LSP violated
// You create one big interface because it feels organized — IWorker with Work(), TakeBreak(), ClockIn(), GetSalary().
// Then a ContractWorker comes along. They work, they clock in — but they don't get a salary through your system, and they don't get scheduled breaks. So they're forced to implement GetSalary() and TakeBreak() and either throw NotSupportedException or return dummy values.
// Industry standard — one method per interface? -- No. That's a misreading of ISP and it's called over-segregation(DI becomes painful) — and it's its own problem -- find the sweet spot.

using System;
using _11_ISP;

namespace _11_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bad Design ===");

            IBadStorage badStorage = new BadArchieve();

            Console.WriteLine("Downloading document...");
            badStorage.Download("doc1");

            Console.WriteLine("Trying to upload (will fail)...");
            try
            {
                badStorage.Upload("doc1", new byte[] { 1, 2, 3 });
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("=== Good Design ===");

            IDocumentReader archive = new GoodArchieve();

            Console.WriteLine("Downloading document...");
            archive.Download("doc1");

            Console.WriteLine("Listing documents...");
            foreach (var doc in archive.ListDocuments())
            {
                Console.WriteLine(doc);
            }

            IStorageMonitor monitor = new GoodArchieve();
            Console.WriteLine("Storage usage: " + monitor.GetStorageUsage());
        }
    }
}