using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_azure_storage
{
    class Blob
    {
        public void UploadToBlob()
        {
            CloudBlobContainer container = getContainerReference();
            var blockBlob = container.GetBlockBlobReference("imgToUpload.jpg");
            using (var fileStream = System.IO.File.OpenRead(@"C:\Users\vbhardwa\Downloads\blob.jpg"))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }
        public void DownloadFromBlob()
        {
            CloudBlobContainer container = getContainerReference();
            var blockBlob = container.GetBlockBlobReference("imgToUpload.jpg");
            using (var fileStream = System.IO.File.OpenWrite(@"C:\Users\vbhardwa\Downloads\blob_download.jpg"))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }

        public void CopyFromBlobToBlob()
        {
            CloudBlobContainer container = getContainerReference();
            var blockBlob = container.GetBlockBlobReference("imgToUpload.jpg");
            var blockCopyBlob = container.GetBlockBlobReference("imgToUpload_copy.jpg");

            
            blockCopyBlob.BeginStartCopy(blockBlob, (x) => { Console.WriteLine("Copy Completed"); }, null);
            using (var fileStream = System.IO.File.OpenWrite(@"C:\Users\vbhardwa\Downloads\blob_download.jpg"))
            {
                blockBlob.DownloadToStream(fileStream);
            }
        }

        private CloudBlobContainer  getContainerReference()
        {
            var storageAccount = CloudStorageAccount.Parse(Microsoft.Azure.CloudConfigurationManager.GetSetting("StorageAccount"));
            var blobClient = storageAccount.CreateCloudBlobClient();

            //container name should be small otherwise bad request error
            var container = blobClient.GetContainerReference("testcontainer");
            container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            return container;

            
        }
    }
}
