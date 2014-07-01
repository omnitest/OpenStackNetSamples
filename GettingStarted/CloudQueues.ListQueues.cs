using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Collections;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Core.Domain.Queues;

namespace GettingStarted.CloudQueues
{
    class ListQueues
    {
        static void Main(string[] args)
        {
            DoListQueues();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoListQueues()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudQueuesProvider cloudQueuesProvider = new CloudQueuesProvider(cloudIdentity, "{region}", Guid.NewGuid(), false, null);
            ReadOnlyCollectionPage<CloudQueue> queueList = await cloudQueuesProvider.ListQueuesAsync(null, null, true, CancellationToken.None);
        }
    }
}
