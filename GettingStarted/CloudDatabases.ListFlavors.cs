using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.Databases;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System;

namespace GettingStarted.CloudDatabases
{
    class ListFlavors
    {
        static void Mainx(string[] args)
        {
            Task<ReadOnlyCollection<DatabaseFlavor>> x = GetFlavorList();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static async Task<ReadOnlyCollection<DatabaseFlavor>> GetFlavorList()
        {
            string region = "IAD";
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };
            ReadOnlyCollection<DatabaseFlavor> databaseFlavorCollection = await new CloudDatabasesProvider(cloudIdentity, "{region}", null).ListFlavorsAsync(CancellationToken.None);
            Console.Write(databaseFlavorCollection.Count);
            foreach (DatabaseFlavor databaseFlavor in databaseFlavorCollection)
            {
                Console.WriteLine(databaseFlavor.Id);
                Console.WriteLine(databaseFlavor.Name);
            }
            return databaseFlavorCollection;
        }
    }
}
