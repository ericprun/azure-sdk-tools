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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS
{
    using System.Management.Automation;
    using Model;
    using Properties;
    using Utilities.Common;

    [Cmdlet(VerbsCommon.Remove, ReservedIPConstants.CmdletNoun, DefaultParameterSetName = RemoveReservedIPParamSet), OutputType(typeof(ManagementOperationContext))]
    public class RemoveAzureReservedIPCmdlet : ServiceManagementBaseCmdlet
    {
        protected const string RemoveReservedIPParamSet = "RemoveReservedIP";

        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, HelpMessage = "Reserved IP Name.")]
        [ValidateNotNullOrEmpty]
        public string ReservedIPName { get; set;}

        [Parameter(Position = 1, HelpMessage = "Do not confirm deletion of deployment")]
        public SwitchParameter Force { get; set; }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveReservedIPWarning),
                Resources.RemoveReservedIPWhatIfMessage,
                string.Empty,
                () =>
                {
                    ExecuteClientActionNewSM(null,
                        CommandRuntime.ToString(),
                        () => NetworkClient.ReservedIPs.Delete(ReservedIPName));
                });
        }
    }
}