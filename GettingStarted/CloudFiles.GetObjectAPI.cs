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
    class GetObjectAPI
    {
        static void Mainx(string[] args)
        {
            DoGetObject();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoGetObject()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudFilesProvider cloudFilesProvider = new CloudFilesProvider(cloudIdentity);

            Stream stream = new FileStream("path_to_file", FileMode.OpenOrCreate);
            cloudFilesProvider.GetObject("{container_name}", "{object_name}", stream);
            FileStream fileStream = File.Create("{path_to_file}", (int)stream.Length);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            fileStream.Write(bytes, 0, bytes.Length);

            // Or, a much simpler way to get an object into a file
            cloudFilesProvider.GetObjectSaveToFile("{container_name}", "{output_folder}", "{object_name}", "{output_filename}");
        }
    }
}
