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
    class ReleaseMessage
    {
        static void Main(string[] args)
        {
            DoReleaseMessage();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoReleaseMessage()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudQueuesProvider cloudQueuesProvider = new CloudQueuesProvider(cloudIdentity, "{region}", Guid.NewGuid(), false, null);
            QueueName queueName = new QueueName("{queue_name}");
            TimeSpan ttl = TimeSpan.FromMinutes(900);
            TimeSpan grace = TimeSpan.FromMinutes(60);
            Claim claim = await cloudQueuesProvider.ClaimMessageAsync(queueName, null, ttl, grace, CancellationToken.None);
            await cloudQueuesProvider.ReleaseClaimAsync(queueName, claim, CancellationToken.None);
        }
    }
}
