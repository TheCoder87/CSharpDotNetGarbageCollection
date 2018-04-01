using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanUpManagedAndUnmanagedResourcesUsingDisposeWithFinalize
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyWrappedResource myWrappedResource = new MyWrappedResource("TestFile.txt"))
            {
                Console.WriteLine("using resource to CleanUp Managed and Unmanaged Resources explicitley calling Dispose()");
            }

            MyWrappedResource wrappedResource = new MyWrappedResource("TestFile.txt");
            Console.WriteLine("Created a new resource, exiting...");
            // Don't CleanUp Explicitley--Let Finalizer get it !


            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
