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
    class SetContainerAsCDN
    {
        static void Main(string[] args)
        {
            DoSetContainerAsCDN();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoSetContainerAsCDN()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudFilesProvider cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            long timeToLive = 604800;
            Dictionary<string, string> header = cloudFilesProvider.EnableCDNOnContainer("{container_name}", timeToLive);
        }
    }
}
