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
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Objects.AutoScale;
using Newtonsoft.Json.Linq;

namespace GettingStarted.AutoScale
{
    class CreateScalingGroup
    {
        static void Main(string[] args)
        {
            DoCreateScalingGroup();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateScalingGroup()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudAutoScaleProvider cloudAutoScaleProvider = 
                new CloudAutoScaleProvider(cloudIdentity,"{region}", null);

            FlavorId flavorId =  new FlavorId("{flavor_id}");
            ImageId imageId = new ImageId("{image_id}");
            string groupName = "{group_name}";
            string serverName = "{server_name}";
            GroupConfiguration groupConfiguration = 
                new GroupConfiguration(
                    name: groupName, 
                    cooldown: TimeSpan.FromSeconds(60), 
                    minEntities: 0, 
                    maxEntities: 0, 
                    metadata: new JObject());
            LaunchConfiguration launchConfiguration = 
                new ServerLaunchConfiguration(
                    new ServerLaunchArguments(
                        new ServerArgument(
                            flavorId, 
                            imageId, 
                            serverName, 
                            null, 
                            null)));
            PolicyConfiguration[] policyConfigurations = { };
            ScalingGroupConfiguration configuration = 
                new ScalingGroupConfiguration(
                    groupConfiguration, 
                    launchConfiguration, 
                    policyConfigurations);
            ScalingGroup scalingGroup = 
                await cloudAutoScaleProvider.CreateGroupAsync(configuration, CancellationToken.None);
        }
    }
}
