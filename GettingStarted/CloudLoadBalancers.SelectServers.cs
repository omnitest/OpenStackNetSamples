using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;


namespace GettingStarted.CloudLoadBalancers
{
    class SelectServers
    {
        static void Main(string[] args)
        {
            DoSelectServers();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoSelectServers()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudServersProvider cloudServersProvider = new CloudServersProvider(cloudIdentity);
            Server server1 = cloudServersProvider.GetDetails("{serverId1}");
            Server server2 = cloudServersProvider.GetDetails("{serverId2}");
        }
    }
}
