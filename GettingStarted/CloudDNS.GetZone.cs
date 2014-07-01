using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Core.Collections;
using net.openstack.Providers;
using net.openstack.Providers.Rackspace.Objects.Dns;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudDNS
{
    class GetZone
    {
        static void  Mainx(string[] args)
        {
            DoGetZone();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoGetZone()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            Console.WriteLine("Getting zone...");

            CloudDnsProvider cloudDNSProvider = new CloudDnsProvider(cloudIdentity, "{region}", true, null);
            Task<ReadOnlyCollection<DnsDomain>> domainsList = (await cloudDNSProvider.ListDomainsAsync("domain.com", null, null, CancellationToken.None)).Item1.GetAllPagesAsync(CancellationToken.None, null);

            Console.WriteLine("Zones retrieved.");
        }
    }
}
