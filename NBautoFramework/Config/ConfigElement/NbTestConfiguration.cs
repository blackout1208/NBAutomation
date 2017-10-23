using System.Configuration;

namespace NBautoFramework.Config.ConfigElement
{
    /// <summary>
    /// NextBitt test configuration class
    /// </summary>
    public class NbTestConfiguration : ConfigurationSection
    {
        private static NbTestConfiguration _TestConfig =
            (NbTestConfiguration)ConfigurationManager.GetSection("NBTestConfiguration");

        /// <summary>
        /// NextBitt test settings
        /// </summary>
        public static NbTestConfiguration NbSettings { get { return _TestConfig; } }

        /// <summary>
        /// Gets the collection of nodes from xml file with the settings of the test
        /// </summary>
        [ConfigurationProperty("testSettings")]
        public NBautoFrameworkElementCollection TestSettingElements
        {
            get
            {
                return (NBautoFrameworkElementCollection)base["testSettings"];
            }
        }
    }
}
