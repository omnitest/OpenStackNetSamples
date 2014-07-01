using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudServers
{
    class ListServers
    {
        static void Main(string[] args)
        {
            DoListServers();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoListServers()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudServersProvider cloudServersProvider = new CloudServersProvider(cloudIdentity);
            IEnumerable<SimpleServer> serverList = cloudServersProvider.ListServers();
        }
    }
}
