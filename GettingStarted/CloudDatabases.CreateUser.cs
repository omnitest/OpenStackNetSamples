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
    class CreateUser
    {
        static void Mainx(string[] args)
        {
            CreateDBUser();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void CreateDBUser()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };

            CloudDatabasesProvider cloudDatabasesProvider = new CloudDatabasesProvider(cloudIdentity, "{region}", null);
            DatabaseInstanceId databaseInstanceId = new DatabaseInstanceId("{database_instance_id}");
            DatabaseName databaseName = new DatabaseName("{databaseName}");
            UserName userName = new UserName("{username}");
            UserConfiguration userConfiguration = new UserConfiguration(userName, "{password}", new DatabaseName[] { databaseName });
            Console.WriteLine("Creating User...");
            await cloudDatabasesProvider.CreateUserAsync(databaseInstanceId, userConfiguration, CancellationToken.None);
            Console.WriteLine("User created.");
        }
    }
}
