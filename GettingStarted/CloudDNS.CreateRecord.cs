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
    class CreateRecord
    {
        static void Mainx(string[] args)
        {
            DoCreateRecord();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateRecord()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "21f4b8b1d4d34ef3b854b119514e9d92",
                Username = "raxschenck"
            };

            Console.WriteLine("Getting zone...");

            CloudDnsProvider cloudDNSProvider = new CloudDnsProvider(cloudIdentity, "{region}", true, null);
            DomainId domainId = new DomainId("{domainId}");
            DnsDomainRecordConfiguration[] recordConfigurations =
                    {
                        new DnsDomainRecordConfiguration(
                            type: DnsRecordType.A,
                            name: string.Format("www.{0}", {domainName}),
                            data: "{data}",
                            timeToLive: null,
                            comment: "{comment}",
                            priority: null)
                    };
            DnsJob<DnsRecordsList> recordsResponse = await cloudDNSProvider.AddRecordsAsync(domainId, recordConfigurations, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
            DnsRecord[] records = recordsResponse.Response.Records.ToArray();

            Console.WriteLine("Zones retrieved.");
        }
    }
}
