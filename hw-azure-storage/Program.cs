using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_azure_storage
{
    class Program
    {
        static void Main(string[] args)
        {
            Blob b = new Blob();
            b.CopyFromBlobToBlob();
            

                Console.ReadKey();
        }
    }
}
