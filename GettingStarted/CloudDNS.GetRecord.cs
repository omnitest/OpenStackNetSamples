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
    class GetRecord
    {
        static void Mainx(string[] args)
        {
            DoGetRecord();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoGetRecord()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            Console.WriteLine("Getting zone...");

            CloudDnsProvider cloudDNSProvider = new CloudDnsProvider(cloudIdentity, "{region}", true, null);
            DomainId domainId = new DomainId("{domainId}");
            Task<ReadOnlyCollection<DnsRecord>> recordsList = (await cloudDNSProvider.ListRecordsAsync(domainId, DnsRecordType.Mx, null, null, null, null, CancellationToken.None)).Item1.GetAllPagesAsync(CancellationToken.None, null);

            Console.WriteLine("Zones retrieved.");
        }
    }
}
