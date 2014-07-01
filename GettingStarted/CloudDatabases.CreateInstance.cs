using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.Databases;

namespace GettingStarted.CloudDatabases
{
    class CreateInstance
    {
        static void Mainx(string[] args)
        {
            Task<DatabaseInstance> x = CreateDatabase();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async Task<DatabaseInstance> CreateDatabase()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            FlavorRef flavorRef = new FlavorRef("{flavor_ref_id}");
            DatabaseVolumeConfiguration databaseVolumeConfiguration = new DatabaseVolumeConfiguration(2);
            DatabaseInstanceConfiguration databaseInstanceConfiguration = new DatabaseInstanceConfiguration(flavorRef, databaseVolumeConfiguration, "{instance_name}");
            CloudDatabasesProvider cloudDatabasesProvider = new CloudDatabasesProvider(cloudIdentity, "{region}", null);
            DatabaseInstance databaseInstance = await cloudDatabasesProvider.CreateDatabaseInstanceAsync(databaseInstanceConfiguration, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);
            return databaseInstance;
        }
    }
}
