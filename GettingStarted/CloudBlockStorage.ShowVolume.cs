using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudBlockStorage
{
    class ShowVolume
    {
        static void Mainx(string[] args)
        {
            string region = "IAD";
            string volumeId = "7654d2e1-b979-48cb-949b-c70a770823cb";
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };
            Volume volume = new CloudBlockStorageProvider(cloudIdentity).ShowVolume(volumeId, region: region);
        }
    }
}
