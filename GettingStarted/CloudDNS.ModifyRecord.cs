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
    class ModifyRecord
    {
        static void Mainx(string[] args)
        {
            DoModifyRecord();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoModifyRecord()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };

            CloudDnsProvider cloudDNSProvider = new CloudDnsProvider(cloudIdentity, "{region}", true, null);
            DomainId domainId = new DomainId("{domain_id}");
            DnsDomainRecordUpdateConfiguration recordUpdateConfiguration = new DnsDomainRecordUpdateConfiguration(records[0], records[0].Name, comment: "{comment}");
            await cloudDNSProvider.UpdateRecordsAsync(domainId, new[] { recordUpdateConfiguration }, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
            DnsRecord updatedRecord = await cloudDNSProvider.ListRecordDetailsAsync(domainId, records[0].Id, CancellationToken.None);
        }
    }
}

