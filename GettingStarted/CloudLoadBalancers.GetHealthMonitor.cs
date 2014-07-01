using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.LoadBalancers;

namespace GettingStarted.CloudLoadBalancers
{
    class GetHealthMonitor
    {
        static void Main(string[] args)
        {
            DoGetHealthMonitor();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoGetHealthMonitor()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudLoadBalancerProvider cloudLoadBalancerProvider = new CloudLoadBalancerProvider(cloudIdentity, "{region}", null);
            LoadBalancerId loadBalancerId = new LoadBalancerId("{load_balancer_id}");
            HealthMonitor healthMonitor = await cloudLoadBalancerProvider.GetHealthMonitorAsync(loadBalancerId, CancellationToken.None);
        }
    }
}
