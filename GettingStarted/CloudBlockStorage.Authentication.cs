//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudBlockStorage
{
    class Authentication
    {
        static void Mainx(string[] args)
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apiKey}",
                Username = "{username}"
            };
            CloudIdentityProvider cloudIdentityProvider = new CloudIdentityProvider(cloudIdentity);
            UserAccess userAccess = cloudIdentityProvider.Authenticate(cloudIdentity);
        }
    }
}
