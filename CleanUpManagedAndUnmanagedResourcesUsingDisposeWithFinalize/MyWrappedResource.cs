using System;
using System.Data;
using System.Runtime.InteropServices;

namespace CleanUpManagedAndUnmanagedResourcesUsingDisposeWithFinalize
{
    public class MyWrappedResource : IDisposable
    {
        [DllImport("kernel32.dll", CharSet =CharSet.Auto, CallingConvention =CallingConvention.StdCall,
            SetLastError =true)]
        static extern IntPtr CreateFile(
            string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            IntPtr SecurityAttributes, uint dwCreationDisposition,
            uint dwFlagsAndAttributes, IntPtr hTemplateFile
            );

        [DllImport("kernel32.dll", SetLastError =true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        
        // IntPtr is used to represent OS handles point to Unmanaged Resource
        IntPtr _handle = IntPtr.Zero;

        //.NET Managed Resource
        IDbConnection _conn = null;

        public MyWrappedResource(string fileName)
        {
            _handle = CreateFile(fileName,
                0x80000000, //access read-only
                1, //shared-read
                IntPtr.Zero,
                3, //open existing
                0,
                IntPtr.Zero
                );
        }

        //Finalizers look like C++ destructors,
        //but they are NOT deterministic
        ~MyWrappedResource()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed = false;
        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                // CleanUp Managed Resources
                if (_conn !=null)
                {
                    _conn.Dispose();
                }
                //we’re already closed, so this object
                //doesn’t need to be finalized anymore
                GC.SuppressFinalize(this);
            }
            if (_handle!=IntPtr.Zero)
            {
                CloseHandle(_handle);
            }

            //in a class hierarchy, don’t forget
            //to call the base class!
            //base.Dispose(disposing);

            _disposed = true;
        }
    }
}