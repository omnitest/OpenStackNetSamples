using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects;
using net.openstack.Providers.Rackspace.Objects.Databases;

namespace GettingStarted.CloudDatabases
{
    class RestoreBackup
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
                APIKey = "21f4b8b1d4d34ef3b854b119514e9d92",
                Username = "raxschenck"
            };

            string region = "IAD";

            CloudDatabasesProvider cloudDatabasesProvider = new CloudDatabasesProvider(cloudIdentity, region, null);
            DatabaseInstanceId databaseInstanceId = new DatabaseInstanceId("800fd447-f2eb-4c41-b1f9-780e6a3ffe7e");

            Console.WriteLine("Restoring from backup...");

//            BackupConfiguration backupConfiguration = new BackupConfiguration(databaseInstanceId, "backup", "Backup Description");
            BackupId backupId = new BackupId("b89b6fe6-ae68-4648-aa53-ac84800cdaf7");            
            RestorePoint restorePoint = new RestorePoint(backupId);
            FlavorRef flavorRef = new FlavorRef("3");
            DatabaseVolumeConfiguration databaseVolumeConfiguration = new DatabaseVolumeConfiguration(2);
            DatabaseInstanceConfiguration databaseInstanceConfiguration = new DatabaseInstanceConfiguration(flavorRef, databaseVolumeConfiguration, "Instance1",restorePoint);
            DatabaseInstance databaseInstance = await cloudDatabasesProvider.CreateDatabaseInstanceAsync(databaseInstanceConfiguration, AsyncCompletionOption.RequestCompleted, CancellationToken.None, null);

            Console.WriteLine("Restore completed!");
        }
    }
}
