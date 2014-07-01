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
    class CreateServerWithKeypair
    {
        static void Main(string[] args)
        {
            DoCreateServerWithKeypair();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoCreateServerWithKeypair()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            // This is not supported through the .NET SDK at this time

        }
    }
}
