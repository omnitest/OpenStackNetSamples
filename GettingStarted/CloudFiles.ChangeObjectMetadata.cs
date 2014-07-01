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
    class ChangeObjectMetadata
    {
        static void Mainx(string[] args)
        {
            DoChangeObjectMetadata();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoChangeObjectMetadata()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudFilesProvider cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            Dictionary<string, string> metadata = new Dictionary<string,string>;
            metadata.Add("{key}","{value}");
            cloudFilesProvider.UpdateObjectMetadata("{container_name}", "{object_name}", metadata, "{region}");
        }
    }
}
