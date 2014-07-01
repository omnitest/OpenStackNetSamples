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
    class CreateQueue
    {
        static void Main(string[] args)
        {
            DoCreateQueue();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateQueue()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudQueuesProvider cloudQueuesProvider = new CloudQueuesProvider(cloudIdentity, "{region}", Guid.NewGuid(), false, null);
            QueueName queueName = new QueueName("{queue_name}");
            bool created = await cloudQueuesProvider.CreateQueueAsync(queueName, CancellationToken.None);
            await cloudQueuesProvider.DeleteQueueAsync(queueName, CancellationToken.None);
        }
    }
}
