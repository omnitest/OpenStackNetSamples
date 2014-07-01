using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;

namespace GettingStarted.CloudServers
{
    class QueryServerBuild
    {
        static void Main(string[] args)
        {
            DoQueryServerBuild();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void DoQueryServerBuild()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudServersProvider cloudServersProvider = new CloudServersProvider(cloudIdentity);
            ServerState[] errorStates = new ServerState[1] { ServerState.Active };
            ServerState[] serverStates = new ServerState[1] { ServerState.Unknown };
            cloudServersProvider.WaitForServerState("{server_id}", serverStates, errorStates);
        }
    }
}
