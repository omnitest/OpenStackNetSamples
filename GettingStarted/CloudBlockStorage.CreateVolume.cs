using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudBlockStorage
{
    class CreateVolume
    {
        static void Mainx(string[] args)
        {
            int GBs = 100; 
            string name = "volume_foo";
            string description = "description_goes_here";
            string region = "IAD";
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };
           new CloudBlockStorageProvider(cloudIdentity).CreateVolume(size: GBs, displayDescription: description, displayName: name, region: region);
        }
    }
}
