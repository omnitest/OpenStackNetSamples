using System.Threading;
using System.Threading.Tasks;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.Databases;
using System.IO;
using System;

namespace GettingStarted.CloudDatabases
{
    class CreateDB
    {
        static void Mainx(string[] args)
        {
            CreateDatabase();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void CreateDatabase()
        {            
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            CloudDatabasesProvider cloudDatabasesProvider = new CloudDatabasesProvider(cloudIdentity, "{region}", null);
            DatabaseInstanceId databaseInstanceId = new DatabaseInstanceId("database_instance_id");
            DatabaseName databaseName = new DatabaseName("{database_name}");
            DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration(databaseName);
            await cloudDatabasesProvider.CreateDatabaseAsync(databaseInstanceId, databaseConfiguration, CancellationToken.None);
            Console.WriteLine("Database created.");
        }
    }
}
