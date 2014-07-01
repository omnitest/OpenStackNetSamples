using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Core.Providers;
using net.openstack.Core.Collections;
using net.openstack.Providers;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.Dns;

namespace GettingStarted.CloudDNS
{
    class DeleteZone
    {
        static void Mainx(string[] args)
        {
            DoDeleteZone();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoDeleteZone()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };

            CloudDnsProvider cloudDNSProvider = new CloudDnsProvider(cloudIdentity, "{region}", true, null);
            DomainId[] domainIds = new DomainId[1];
            DnsJob deleteResponse = await cloudDNSProvider.RemoveDomainsAsync(domainIds, false, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
        }
    }
}
