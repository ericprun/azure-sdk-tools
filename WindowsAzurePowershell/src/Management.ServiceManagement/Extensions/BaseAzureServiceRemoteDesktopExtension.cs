﻿// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.ServiceManagement.Extensions
{
    using System;
    using System.Xml.Linq;
    using WindowsAzure.ServiceManagement;
    using System.Security;
    using System.Security.Permissions;
    using System.Runtime.InteropServices;

    // From GithubClient.cs
    public static class SecureStringExtensionMethods
    {
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

    public abstract class BaseAzureServiceRemoteDesktopExtensionCmdlet : BaseAzureServiceExtensionCmdlet
    {
        protected const string UserNameElemStr = "UserName";
        protected const string ExpirationElemStr = "Expiration";
        protected const string PasswordElemStr = "Password";

        public BaseAzureServiceRemoteDesktopExtensionCmdlet()
            : base()
        {
            Initialize();
        }

        public BaseAzureServiceRemoteDesktopExtensionCmdlet(IServiceManagement channel)
            : base(channel)
        {
            Initialize();
        }

        protected void Initialize()
        {
            ExtensionNameSpace = "Microsoft.Windows.Azure.Extensions";
            ExtensionType = "RDP";

            PublicConfigurationXmlTemplate = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XProcessingInstruction("xml-stylesheet", @"type=""text/xsl"" href=""style.xsl"""),
                new XElement(PublicConfigStr,
                    new XElement(UserNameElemStr, "{0}"),
                    new XElement(ExpirationElemStr, "{1}")
                )
            );

            PrivateConfigurationXmlTemplate = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XProcessingInstruction("xml-stylesheet", @"type=""text/xsl"" href=""style.xsl"""),
                new XElement(PrivateConfigStr,
                    new XElement(PasswordElemStr, "{0}")
                )
            );
        }
    }
}
