using System.Collections.Generic;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudBlockStorage
{
    class ListSnapshots
    {
        static void Mainx(string[] args)
        {
            string region = "IAD";
            CloudIdentity cid = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };
            CloudBlockStorageProvider cbsp = new CloudBlockStorageProvider(cid);
            IEnumerable<Snapshot> snapshotList = cbsp.ListSnapshots(region: region);
        }
    }
}
