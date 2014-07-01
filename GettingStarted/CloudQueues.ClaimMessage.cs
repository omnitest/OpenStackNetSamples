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
using net.openstack.Core.Domain.Queues;

namespace GettingStarted.CloudQueues
{
    class ClaimMessage
    {
        static void Main(string[] args)
        {
            DoClaimMessage();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoClaimMessage()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudQueuesProvider cloudQueuesProvider = new CloudQueuesProvider(cloudIdentity, "{region}", Guid.NewGuid(), false, null);
            QueueName queueName = new QueueName("{queue_name}");
            int limit = 4;
            TimeSpan ttl = TimeSpan.FromMinutes(900);
            TimeSpan grace = TimeSpan.FromMinutes(120)
            Claim claim = await cloudQueuesProvider.ClaimMessageAsync(queueName, limit , ttl, grace, CancellationToken.None);
        }
    }
}
