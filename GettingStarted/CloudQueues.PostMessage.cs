﻿using System.IO;
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
    class PostMessage
    {
        static void Main(string[] args)
        {
            DoPostMessage();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoPostMessage()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudQueuesProvider cloudQueuesProvider = new CloudQueuesProvider(cloudIdentity, "{region}", Guid.NewGuid(), false, null);
            QueueName queueName = new QueueName("{queue_name}");
            TimeSpan ttl = TimeSpan.FromMinutes(900);
            Newtonsoft.Json.Linq.JObject message_body = new Newtonsoft.Json.Linq.JObject("{\"play\": \"hockey\"}");
            Message message = new Message(ttl, message_body);
            Message[] messages = { message };
            await cloudQueuesProvider.PostMessagesAsync(queueName, CancellationToken.None, messages);
        }
    }
}
