using System.Configuration;

namespace NBautoFramework.Config.ConfigElement
{
    /// <summary>
    /// 
    /// </summary>
    public class NBautoFrameworkElement : ConfigurationElement
    {
        /// <summary>
        /// BrowserType attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("browserType", IsRequired = true)]
        public string BrowserType { get { return (string)base["browserType"]; } }

        /// <summary>
        /// DbConnectionString attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("dbConnectionString", IsRequired = true)]
        public string DbConnectionString { get { return (string)base["dbConnectionString"]; } }

        /// <summary>
        /// Environment attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("environment", IsRequired = true)]
        public string Environment { get { return (string)base["environment"]; } }

        /// <summary>
        /// IsToLog attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("isToLog", IsRequired = true)]
        public string IsToLog { get { return (string)base["isToLog"]; } }

        /// <summary>
        ///     IsToReport attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("isToReport", IsRequired = true)]
        public string IsToReport
        {
            get { return (string) base["isToReport"]; }
        }

        /// <summary>
        ///     TestType attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("testType", IsRequired = true)]
        public string TestType
        {
            get { return (string) base["testType"]; }
        }

        /// <summary>
        /// Url attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("url", IsRequired = true)]
        public string Url { get { return (string)base["url"]; } }
    }
}
