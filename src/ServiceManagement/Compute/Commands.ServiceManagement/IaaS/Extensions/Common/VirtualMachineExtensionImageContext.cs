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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    using System;
    using Utilities.Common;

    public class VirtualMachineExtensionImageContext : ManagementOperationContext
    {
        public string Publisher { get; set; }
        public string ExtensionName { get; set; }
        public string Version { get; set; }
        public string PublicConfigurationSchema { get; set; }
        public string PrivateConfigurationSchema { get; set; }
        public string SampleConfig { get; set; }
        public bool ReplicationCompleted { get; private set; }
        public Uri Eula { get; private set; }
        public Uri PrivacyUri { get; private set; }
        public Uri HomepageUri { get; private set; }
        public bool IsJsonExtension { get; private set; }
    }
}
