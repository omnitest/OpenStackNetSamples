﻿using System.IO;
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
    class UpdateScalingWebhook
    {
        static void Main(string[] args)
        {
            DoUpdateScalingWebhook();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoUpdateScalingWebhook()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = new CloudAutoScaleProvider(cloudIdentity, "{region}", null);
            // update the webhook name
            string updatedName = "Updated Webhook";
            await cloudAutoScaleProvider.UpdateWebhookAsync({group_id}, {policy_id}, {webhook_id}, new UpdateWebhookConfiguration(updatedName), CancellationToken.None);
        }
    }
}
