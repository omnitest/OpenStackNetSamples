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
using net.openstack.Providers.Rackspace.Objects.Monitoring;
using Newtonsoft.Json.Linq;
using HttpMethod = JSIStudios.SimpleRESTServices.Client.HttpMethod;

namespace GettingStarted.CloudMonitoring
{
    class CreateCheck
    {
        static void Main(string[] args)
        {
            DoCreateCheck();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static async void DoCreateCheck()
        {
            CloudIdentity cloudIdentity = new CloudIdentity()
            {
                APIKey = "{apikey}",
                Username = "{username}"
            };
            CloudMonitoringProvider cloudMonitoringProvider = new CloudMonitoringProvider(cloudIdentity, "{region}", null);
            CheckTypeId checkTypeId = CheckTypeId.RemoteHttp;
            CheckDetails details = new HttpCheckDetails( 
                    url: new Uri("http://docs.rackspace.com", UriKind.Absolute),
                    authUser: default(string),
                    authPassword: default(string),
                    body: default(string),
                    bodyMatches: default(IDictionary<string, string>),
                    followRedirects: default(bool?),
                    headers: default(IDictionary<string, string>),
                    method: default(HttpMethod?),
                    payload: default(string));

            IEnumerable<MonitoringZoneId> monitoringZonesPoll = new[] { "{zone_id}" };
            TimeSpan? timeout = null;
            TimeSpan? period = null;
            string targetAlias = null;
            string targetHostname = "www.example.com";
            TargetResolverType resolverType = TargetResolverType.IPv4;
            IDictionary<string, string> metadata = null;
            NewCheckConfiguration checkConfiguration = new NewCheckConfiguration("{check_label}", checkTypeId, details, monitoringZonesPoll, timeout, period, targetAlias, targetHostname, resolverType, metadata);
            Check check = await cloudMonitoringProvider.CreateCheckAsync({entity_id}, {check_configuration}, CancellationToken.None);
        }
    }
}
