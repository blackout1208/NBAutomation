using System.Data.SqlClient;
using NBautoFramework.Base;

namespace NBautoFramework.Config
{
    /// <summary>
    /// Application Settings Class
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// The Type of Browser to run the test
        /// </summary>
        public static BrowserType BrowserType { get; set; }

        /// <summary>
        /// The DB connection.
        /// </summary>
        public static SqlConnection DbConnection { get; set; }

        /// <summary>
        /// The DB connection string
        /// </summary>
        public static string DbConnectionString { get; set; }

        /// <summary>
        /// Drivers folder where the drivers to run the browsers are set
        /// </summary>
        public static string DriversFolder { get; set; }

        /// <summary>
        /// The Environment where the test is to be runned.
        /// </summary>
        public static string Environment { get; set; }

        /// <summary>
        /// Is this test to save logs?
        /// </summary>
        public static bool IsToLog { get; set; }

        /// <summary>
        /// Is this test to save reports?
        /// </summary>
        public static bool IsToReport { get; set; }

        /// <summary>
        /// The path of the folder where the logs are stored
        /// </summary>
        public static string LogsFolder { get; set; }

        /// <summary>
        /// Type of test
        /// </summary>
        public static string TestType { get; set; }

        /// <summary>
        /// The URL to webpage to be tested
        /// </summary>
        public static string Url { get; set; }
    }
}
