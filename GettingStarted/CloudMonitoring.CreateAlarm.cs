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
    class CreateAlarm
    {
        static void Main(string[] args)
        {
            DoCreateAlarm();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateAlarm()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudMonitoringProvider cloudMonitoringProvider = new CloudMonitoringProvider(cloudIdentity, "{region}", null);

            string alarmName = "{alarm_name}";
            string criteria = null;
            bool? enabled = null;
            IDictionary<string, string> alarmMetadata = null;
            NewAlarmConfiguration alarmConfiguration = new NewAlarmConfiguration({check_id}, {notification_plan_id}, criteria, enabled, alarmName, alarmMetadata);
            AlarmId alarmId = await cloudMonitoringProvider.CreateAlarmAsync({entity_id}, alarmConfiguration, CancellationToken.None);
        }
    }
}
