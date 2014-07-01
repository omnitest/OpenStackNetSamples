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
    class BlacklistIPs
    {
        static void Main(string[] args)
        {
            DoBlacklistIPs();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoBlacklistIPs()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudLoadBalancerProvider cloudLoadBalancerProvider = new CloudLoadBalancerProvider(cloudIdentity, "{region}", null);
            LoadBalancerId loadBalancerId = new LoadBalancerId("{load_balancer_id}");
            NetworkItem networkItem = new NetworkItem("206.160.165.0/24", AccessType.Deny);
            await cloudLoadBalancerProvider.CreateAccessListAsync(loadBalancerId, networkItem, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
        }
    }
}
