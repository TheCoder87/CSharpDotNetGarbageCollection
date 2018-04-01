using System;

namespace MemoryUsageOfApplicationDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int allocatedSize = 1024;   // 1KB = 1024 bytes
            long availableMemoryBefore = GC.GetTotalMemory(false);
            Console.WriteLine("Before Allocations: {0} KB", availableMemoryBefore / allocatedSize);

            byte[] bigArray = new byte[allocatedSize];

            long availableMemoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("After Allocations: {0} KB", availableMemoryAfter / allocatedSize);

            Console.WriteLine("Allocations increamented by: {0} KB", (availableMemoryAfter - availableMemoryBefore) / allocatedSize);


            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
