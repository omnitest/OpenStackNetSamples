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
    class CreateNotification
    {
        static void Main(string[] args)
        {
            DoCreateNotification();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateNotification()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudMonitoringProvider cloudMonitoringProvider = new CloudMonitoringProvider(cloudIdentity, "{region}", null);
            NotificationTypeId notificationTypeId = NotificationTypeId.Webhook;
            NotificationDetails notificationDetails = new WebhookNotificationDetails(new Uri("http://example.com"));
            NewNotificationConfiguration configuration = new NewNotificationConfiguration("{notification_label}", notificationTypeId, notificationDetails);
            NotificationId notificationId = await cloudMonitoringProvider.CreateNotificationAsync(configuration, CancellationToken.None);
        }
    }
}
