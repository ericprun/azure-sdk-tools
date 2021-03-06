﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    using Model.PersistentVMModel;
    using System.Collections.Generic;
    using Utilities.Common;

    public class VirtualNetworkSiteContext : ManagementOperationContext
    {
        public IEnumerable<string> AddressSpacePrefixes { get; set; }

        public string AffinityGroup { get; set; }

        public IEnumerable<DnsServer> DnsServers { get; set; }

        public string GatewayProfile { get; set; }

        public LocalNetworkSiteList GatewaySites { get; set; }

        public string Id { get; set; }
        
        public bool InUse { get; set; }

        public string Label { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public IEnumerable<Subnet> Subnets { get; set; }
    }
}
