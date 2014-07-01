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
    class EnableContentCaching
    {
        static void Main(string[] args)
        {
            DoEnableContentCaching();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoEnableContentCaching()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudLoadBalancerProvider cloudLoadBalancerProvider = new CloudLoadBalancerProvider(cloudIdentity, "{region}", null);
            LoadBalancerId loadBalancerId = new LoadBalancerId("{load_balancer_id}");
            await cloudLoadBalancerProvider.SetContentCachingAsync(loadBalancerId, true, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
        }
    }
}
