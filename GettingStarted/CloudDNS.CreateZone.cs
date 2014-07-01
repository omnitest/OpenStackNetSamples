using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Collections;
using net.openstack.Core.Domain;
using net.openstack.Providers;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.Dns;


namespace GettingStarted.CloudDNS
{
    class CreateZone
    {
        static void Mainx(string[] args)
        {
            CreateDomain();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void CreateDomain()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            Console.WriteLine("Creating domain...");

            CloudDnsProvider cloudDnsProvider = new CloudDnsProvider(cloudIdentity, "{region}", true, null);
            DnsConfiguration dnsConfiguration = new DnsConfiguration(
                new DnsDomainConfiguration(
                    name: "domain.com",
                    timeToLive: default(TimeSpan?),
                    emailAddress: "admin@domain.com",
                    comment: "This is a test",
                    records: new DnsDomainRecordConfiguration[] { },
                    subdomains: new DnsSubdomainConfiguration[] { }));
            DnsJob<DnsDomains> createResponse = await cloudDnsProvider.CreateDomainsAsync(dnsConfiguration, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);

            Console.WriteLine("Database created.");
        }
    }
}
