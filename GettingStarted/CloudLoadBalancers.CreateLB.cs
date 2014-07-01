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
    class CreateLB
    {
        static void Main(string[] args)
        {
            DoCreateLB();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateLB()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudLoadBalancerProvider cloudLoadBalancerProvider = new CloudLoadBalancerProvider(cloudIdentity, "{region}", null);
            IEnumerable<LoadBalancingProtocol> protocols = await cloudLoadBalancerProvider.ListProtocolsAsync(CancellationToken.None);
            LoadBalancingProtocol httpProtocol = protocols.First(i => i.Name.Equals("HTTP", StringComparison.OrdinalIgnoreCase));
            LoadBalancerConfiguration configuration = new LoadBalancerConfiguration(
                name: "{load_balancer_name}",
                nodes: null,
                protocol: httpProtocol,
                virtualAddresses: new[] { new LoadBalancerVirtualAddress(LoadBalancerVirtualAddressType.ServiceNet) },
                algorithm: LoadBalancingAlgorithm.RoundRobin);
            LoadBalancer tempLoadBalancer = await cloudLoadBalancerProvider.CreateLoadBalancerAsync(configuration, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
        }
    }
}
