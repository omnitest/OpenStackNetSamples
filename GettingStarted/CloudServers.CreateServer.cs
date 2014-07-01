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
    class CreateServer
    {
        static void Main(string[] args)
        {
            DoCreateServer();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoCreateServer()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudServersProvider cloudServersProvider = new CloudServersProvider(cloudIdentity);
            cloudServersProvider.CreateServer("{server_name}", "{image_id}", "{flavor_id}");
        }
    }
}
