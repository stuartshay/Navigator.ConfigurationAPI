using System;
using System.Collections.Generic;
using Navigator.ConfigurationAPI.Configuration;

namespace Navigator.ConfigurationAPI.ViewModels
{
    public class ServerDiagnostics
    {
        /// <summary>
        /// Application Name
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Application Version Number
        /// </summary>
        public string ApplicationVersionNumber { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///  Environment Name
        /// </summary>
        public string EnvironmentName { get; set; }

        /// <summary>
        /// Platform
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Working Directory
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// Content Root Path
        /// </summary>
        public string ContentRootPath { get; set; }

        /// <summary>
        /// Web Root Path
        /// </summary>
        public string WebRootPath { get; set; }

        /// <summary>
        /// Dns Host Name
        /// </summary>
        public string DnsHostName { get; set; }

        /// <summary>
        /// Machine Name
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Machine Date
        /// </summary>
        public DateTime MachineDate { get; set; }

        /// <summary>
        /// Machine Culture
        /// </summary>
        public string MachineCulture { get; set; }

        /// <summary>
        /// Machine TimeZone
        /// </summary>
        public string MachineTimeZone { get; set; }

        /// <summary>
        /// Run Time
        /// </summary>
        public string Runtime { get; set; }

        /// <summary>
        /// Ip Address List
        /// </summary>
        public IEnumerable<string> IpAddressList { get; set; }


        /// <summary>
        /// End Point Configuration
        /// </summary>
        public EndPointConfiguration EndPointConfiguration { get; set; }

    }
}
