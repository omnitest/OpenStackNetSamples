using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.Databases;
using net.openstack.Core.Collections;

namespace GettingStarted.CloudDatabases
{
    class ListInstances
    {
        static void Mainx(string[] args)
        {
            Task<ReadOnlyCollectionPage<DatabaseInstance>> x = ListDBInstances();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async Task<ReadOnlyCollectionPage<DatabaseInstance>> ListDBInstances()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            string region = "IAD";

            CloudDatabasesProvider cloudDatabasesProvider = new CloudDatabasesProvider(cloudIdentity, region, null);
            DatabaseInstanceId databaseInstanceId = new DatabaseInstanceId("0");
            CancellationToken cancellationToken = new CancellationToken(false);
            Console.WriteLine("Gathering list...");
            ReadOnlyCollectionPage<DatabaseInstance> dbilist = await cloudDatabasesProvider.ListDatabaseInstancesAsync(databaseInstanceId, 99, cancellationToken);
            Console.WriteLine("Here's your list of instances!");
            foreach (DatabaseInstance dbi in dbilist)
            {
                Console.WriteLine(dbi.Id);
            }
            Console.WriteLine("END OF LIST");
            return dbilist;
        }
    }
}
