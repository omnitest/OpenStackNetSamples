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
    class GetObjectCDN
    {
        static void Mainx(string[] args)
        {
            DoGetObjectCDN();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoGetObjectCDN()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudFilesProvider cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            ContainerCDN container = cloudFilesProvider.GetContainerCDNHeader(container: "{container_name}");
            string urlForHTTP = container.CDNUri;
            string urlForHTTPS = container.CDNSslUri;
            string urlForiOSStreaming = container.CDNIosUri;
            string urlForStreaming = container.CDNStreamingUri;
        }
    }
}
