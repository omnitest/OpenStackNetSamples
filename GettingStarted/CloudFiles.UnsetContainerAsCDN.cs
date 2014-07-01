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
    class UnsetContainerAsCDN
    {
        static void Main(string[] args)
        {
            DoUnsetContainerAsCDN();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoUnsetContainerAsCDN()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudFilesProvider cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            cloudFilesProvider.DisableCDNOnContainer("{container_name}");
        }
    }
}
