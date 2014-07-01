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
    class ListFlavors
    {
        static void Main(string[] args)
        {
            DoListFlavors();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoListFlavors()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudServersProvider cloudServersProvider = new CloudServersProvider(cloudIdentity);
            IEnumerable<Flavor> flavorList = cloudServersProvider.ListFlavors();
        }
    }
}
