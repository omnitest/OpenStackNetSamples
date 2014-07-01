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
using net.openstack.Providers.Rackspace.Objects.LoadBalancers;

namespace GettingStarted.CloudLoadBalancers
{
    class QueryLBProgress
    {
        static void Main(string[] args)
        {
            DoQueryLBProgress();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoQueryLBProgress()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudLoadBalancerProvider cloudLoadBalancerProvider = new CloudLoadBalancerProvider(cloudIdentity, "{region}", null);
            int limit = 1;
            ReadOnlyCollection<LoadBalancer> loadBalancers = await (await cloudLoadBalancerProvider.ListLoadBalancersAsync(null, limit, CancellationToken.None)).GetAllPagesAsync(CancellationToken.None, null);
            LoadBalancerStatus loadBalancerStatus = loadBalancers[0].Status;
            // Values include:
            // LoadBalancerStatus.Active;
            // LoadBalancerStatus.Build;
            // LoadBalancerStatus.Deleted;
            // LoadBalancerStatus.Error;
            // LoadBalancerStatus.PendingDelete;
            // LoadBalancerStatus.PendingUpdate;
            // LoadBalancerStatus.Suspended;
        }
    }
}
