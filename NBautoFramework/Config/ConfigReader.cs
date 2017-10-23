using System;
using NBautoFramework.Base;
using NBautoFramework.Config.ConfigElement;

namespace NBautoFramework.Config
{
    /// <summary>
    /// Reads the settings in xml config file
    /// </summary>
    public class ConfigReader
    {
        /// <summary>
        /// Read the attributes from the setting node in xml
        /// </summary>
        /// <param name="environment">The value of the environment to test</param>
        public static void SetFrameworkSettings(string environment)
        {
            Settings.DriversFolder = NbTestConfiguration.NbSettings.TestSettingElements.DriversFolder;
            Settings.LogsFolder = NbTestConfiguration.NbSettings.TestSettingElements.LogsFolder;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), NbTestConfiguration.NbSettings.TestSettingElements[environment].BrowserType);
            Settings.DbConnectionString = NbTestConfiguration.NbSettings.TestSettingElements[environment].DbConnectionString;
            Settings.IsToLog = bool.Parse(NbTestConfiguration.NbSettings.TestSettingElements[environment].IsToLog);
            Settings.IsToReport = bool.Parse(NbTestConfiguration.NbSettings.TestSettingElements[environment].IsToReport);
            Settings.TestType = NbTestConfiguration.NbSettings.TestSettingElements[environment].TestType;
            Settings.Url = NbTestConfiguration.NbSettings.TestSettingElements[environment].Url;
        }
    }
}
