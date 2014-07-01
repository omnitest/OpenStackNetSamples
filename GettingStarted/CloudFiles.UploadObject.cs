using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudFiles
{
    class UploadObject
    {
        static void Main(string[] args)
        {
            DoUploadObject();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoUploadObject()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudFilesProvider cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            FileStream fileStream = new FileStream("{path_to_file}", FileMode.Open, FileAccess.Read);
            int fileLength = (int)fileStream.Length;
            byte[] buffer = new byte[fileLength];
            int nbrOfBytes;
            int bytesRead = 0;
            while ((nbrOfBytes = fileStream.Read(buffer, bytesRead, fileLength - bytesRead)) > 0)
                bytesRead += nbrOfBytes;  
            fileStream.Close();
            using (fileStream)
            {
                cloudFilesProvider.CreateObject("{container_name}", fileStream, "{object_name}");
            }

            // OR, much simpler...
            cloudFilesProvider.CreateObjectFromFile("{container_name}", "{path_to_file}", "{object_name}");
        }
    }
}
