using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Collections;
using net.openstack.Core.Domain;
using net.openstack.Core.Providers;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.Monitoring;
using Newtonsoft.Json.Linq;

namespace GettingStarted.CloudMonitoring
{
    class ListChecks
    {
        static void Main(string[] args)
        {
            DoListChecks();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoListChecks()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudMonitoringProvider cloudMonitoringProvider = new CloudMonitoringProvider(cloudIdentity, "{region}", null);
            ReadOnlyCollectionPage<Check, CheckId> checks = await cloudMonitoringProvider.ListChecksAsync({entity_id}, null, null, CancellationToken.None);
        }
    }
}
