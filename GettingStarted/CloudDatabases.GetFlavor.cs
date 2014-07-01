using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects;
using net.openstack.Providers.Rackspace.Objects.Databases;

namespace GettingStarted.CloudDatabases
{
    class GetFlavor
    {
        static void Mainx(string[] args)
        {
            Task<DatabaseFlavor> x = GetDBFlavor();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async Task<DatabaseFlavor> GetDBFlavor()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            CloudDatabasesProvider cloudDatabasesProvider = new CloudDatabasesProvider(cloudIdentity, "{region}", null);
            Console.WriteLine("Getting Flavor...");
            net.openstack.Providers.Rackspace.Objects.Databases.FlavorId flavorId = new net.openstack.Providers.Rackspace.Objects.Databases.FlavorId("{flavor_id}");
            DatabaseFlavor databaseFlavor = await cloudDatabasesProvider.GetFlavorAsync(flavorId, CancellationToken.None);

            Console.WriteLine("About the Flavor:");
            Console.WriteLine(databaseFlavor.Id);
            Console.WriteLine(databaseFlavor.Name);
            Console.WriteLine("END OF LIST");
            return databaseFlavor;
        }
    }
}
