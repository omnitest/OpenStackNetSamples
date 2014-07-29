using System.IO;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using net.openstack.Core;
using net.openstack.Core.Collections;
using net.openstack.Core.Domain;
using net.openstack.Core.Providers;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.AutoScale;
using Newtonsoft.Json.Linq;

namespace GettingStarted.AutoScale
{
    class DeleteScalingGroup
    {
        static void Main(string[] args)
        {
            DoDeleteScalingGroup();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoDeleteScalingGroup()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = new CloudAutoScaleProvider(cloudIdentity, "{region}", null);
            await cloudAutoScaleProvider.DeleteGroupAsync({group_id}, true, CancellationToken.None);
        }
    }
}
