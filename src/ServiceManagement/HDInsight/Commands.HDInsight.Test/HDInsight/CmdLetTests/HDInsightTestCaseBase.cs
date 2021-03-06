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
namespace Microsoft.WindowsAzure.Commands.Test.HDInsight.CmdLetTests
{
    using Management.HDInsight.Cmdlet.PSCmdlets;
    using Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
    using Utilities.HDInsight.Utilities;

    public class HDInsightTestCaseBase : IntegrationTestBase
    {
        public override void Initialize()
        {
            base.Initialize();
            this.SetCurrentSubscription();
        }

        public override void TestCleanup()
        {
            base.TestCleanup();
            ResetCurrentSubscription();
        }

        protected IRunspace GetPowerShellRunspace()
        {
            string location = typeof(GetAzureHDInsightClusterCmdlet).Assembly.Location;
            return base.GetPowerShellRunspace(location);
        }

        private void SetCurrentSubscription()
        {
            AzureHDInsightCmdlet.testSubscription = GetCurrentSubscription();
        }

        private void ResetCurrentSubscription()
        {
            AzureHDInsightCmdlet.testSubscription = null;
        }
    }
}
