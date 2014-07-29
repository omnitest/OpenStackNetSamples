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
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.AutoScale;
using Newtonsoft.Json.Linq;

namespace GettingStarted.AutoScale
{
    class CreateScalingPolicy
    {
        static void Main(string[] args)
        {
            DoCreateScalingPolicy();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateScalingPolicy()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = new CloudAutoScaleProvider(cloudIdentity, "{region}", null);
            
            PolicyConfiguration policyConfiguration = PolicyConfiguration.Capacity("Capacity 0 Policy", 0, TimeSpan.FromSeconds(60));
            Policy policy = await cloudAutoScaleProvider.CreatePolicyAsync({group_id}, policyConfiguration, CancellationToken.None);
        }
    }
}
