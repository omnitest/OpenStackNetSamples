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
    class CreateHealthMonitor
    {
        static void Main(string[] args)
        {
            DoCreateHealthMonitor();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateHealthMonitor()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudLoadBalancerProvider cloudLoadBalancerProvider = new CloudLoadBalancerProvider(cloudIdentity, "{region}", null);
            LoadBalancerId loadBalancerId = new LoadBalancerId("{load_balancer_id}");
            int attemptsBeforeDeactivation = 3;
            TimeSpan timeout = TimeSpan.FromSeconds(30);
            TimeSpan delay = TimeSpan.FromSeconds(30); HealthMonitor healthMonitor = new ConnectionHealthMonitor(attemptsBeforeDeactivation, timeout, delay);
            await cloudLoadBalancerProvider.SetHealthMonitorAsync(loadBalancerId, healthMonitor, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
       }
    }
}
