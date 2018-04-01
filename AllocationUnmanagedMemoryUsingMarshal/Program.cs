using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllocationUnmanagedMemoryUsingMarshal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Memory usage before unmanaged allocation: {0:N0}", GC.GetTotalMemory(false));
            MyDataClass obj = new MyDataClass(10000000);
            //unmanaged memory is not counted!
            Console.WriteLine("Memory usage after unmanaged allocation: {0:N0}", GC.GetTotalMemory(false));


            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
