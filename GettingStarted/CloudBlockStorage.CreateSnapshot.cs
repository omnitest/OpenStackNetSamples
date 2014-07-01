using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudBlockStorage
{
    class CreateSnapshot
    {
        static void Mainx(string[] args)
        {
            string volumeId = "volumeId_goes_here";
            string name = "snapshot_name";
            string description = "description_goes_here";
            string region = "IAD";
            CloudIdentity cid = new CloudIdentity()
            {
                APIKey = "apikey_goes_here",
                Username = "username_goes_here"
            };
            CloudBlockStorageProvider cbsp = new CloudBlockStorageProvider(cid);
            cbsp.CreateSnapshot(volumeId, displayName: name, displayDescription: description, region: region);
        }
    }
}
