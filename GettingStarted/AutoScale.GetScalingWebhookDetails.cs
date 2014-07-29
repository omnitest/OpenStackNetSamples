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
using net.openstack.Providers.Rackspace.Objects.AutoScale;
using Newtonsoft.Json.Linq;

namespace GettingStarted.AutoScale
{
    class GetScalingWebhookDetails
    {
        static void Main(string[] args)
        {
            DoGetScalingWebhookDetails();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoGetScalingWebhookDetails()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = new CloudAutoScaleProvider(cloudIdentity, "{region}", null);
            Webhook webhook = await cloudAutoScaleProvider.GetWebhookAsync({group_id}, {policy_id}, {webhook_id}, CancellationToken.None);
        }
    }
}
