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
    class ListMonitoringZones
    {
        static void Main(string[] args)
        {
            DoListMonitoringZones();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoListMonitoringZones()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudMonitoringProvider cloudMonitoringProvider = new CloudMonitoringProvider(cloudIdentity, "{region}", null);
            ReadOnlyCollectionPage<MonitoringZone, MonitoringZoneId> monitoringZones = await cloudMonitoringProvider.ListMonitoringZonesAsync(null, null, CancellationToken.None);
        }
    }
}
