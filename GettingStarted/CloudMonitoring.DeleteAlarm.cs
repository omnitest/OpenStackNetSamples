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
    class DeleteAlarm
    {
        static void Main(string[] args)
        {
            DoDeleteAlarm();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoDeleteAlarm()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudMonitoringProvider cloudMonitoringProvider = new CloudMonitoringProvider(cloudIdentity, "{region}", null);
            await cloudMonitoringProvider.RemoveAlarmAsync({entity_id}, {alarm_id}, CancellationToken.None);
        }
    }
}
