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
    class CreateScalingWebhook
    {
        static void Main(string[] args)
        {
            DoCreateScalingWebhook();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateScalingWebhook()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = new CloudAutoScaleProvider(cloudIdentity, "{region}", null);
            NewWebhookConfiguration webhookConfiguration = new NewWebhookConfiguration("Test Webhook");
            Webhook webhook = await cloudAutoScaleProvider.CreateWebhookAsync(scalingGroup.Id, scalingGroup.ScalingPolicies[0].Id, webhookConfiguration, CancellationToken.None);
        }
    }
}
