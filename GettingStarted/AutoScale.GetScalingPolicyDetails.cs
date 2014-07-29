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
    class GetScalingPolicyDetails
    {
        static void Main(string[] args)
        {
            DoGetScalingPolicyDetails();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoGetScalingPolicyDetails()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = new CloudAutoScaleProvider(cloudIdentity, "{region}", null);
            Policy policy = await cloudAutoScaleProvider.GetPolicyAsync({group_id}, {policy_id}, CancellationToken.None);
        }
    }
}
