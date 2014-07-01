using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudBlockStorage
{
    class DeleteSnapshot
    {
        static void Mainx(string[] args)
        {
            string region = "IAD";
            string snapshotId = "0ecd4715-4060-495f-a8a5-c34779d3d68e";
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };
            new CloudBlockStorageProvider(cloudIdentity).DeleteSnapshot(snapshotId, region);            
        }
    }
}
