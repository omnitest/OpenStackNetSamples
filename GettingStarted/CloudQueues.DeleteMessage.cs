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
    class DeleteMessage
    {
        static void Main(string[] args)
        {
            DoDeleteMessage();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoDeleteMessage()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudQueuesProvider cloudQueuesProvider = new CloudQueuesProvider(cloudIdentity, "{region}", Guid.NewGuid(), false, null);
            QueueName queueName = new QueueName("{queue_name}");
            MessageId messageId = new MessageId("message_id");
            await cloudQueuesProvider.DeleteMessageAsync(queueName, messageId, null, CancellationToken.None);
        }
    }
}
