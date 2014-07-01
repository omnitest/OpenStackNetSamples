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
    class SetThrottling
    {
        static void Main(string[] args)
        {
            DoSetThrottling();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoSetThrottling()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudLoadBalancerProvider cloudLoadBalancerProvider = new CloudLoadBalancerProvider(cloudIdentity, "{region}", null);
            LoadBalancerId loadBalancerId = new LoadBalancerId("{load_balancer_id}");
            int maxConnectionRate = 10000;
            int maxConnections = 5000;
            int minConnections = 2;
            TimeSpan rateInterval = TimeSpan.FromSeconds(5);
            ConnectionThrottles throttles = new ConnectionThrottles(maxConnectionRate, maxConnections, minConnections, rateInterval);
            await cloudLoadBalancerProvider.UpdateThrottlesAsync(loadBalancerId, throttles, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);    
        }
    }
}
