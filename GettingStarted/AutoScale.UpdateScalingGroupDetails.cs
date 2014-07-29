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
    class UpdateScalingGroupDetails
    {
        static void Main(string[] args)
        {
            DoUpdateScalingGroupDetails();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoUpdateScalingGroupDetails()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = new CloudAutoScaleProvider(cloudIdentity, "{region}", null);
            TimeSpan cooldown = TimeSpan.FromSeconds(60);
            await cloudAutoScaleProvider.SetGroupConfigurationAsync({group_id}, new GroupConfiguration("group_name", cooldown, 0, 0, new JObject()), CancellationToken.None);
        }
    }
}
