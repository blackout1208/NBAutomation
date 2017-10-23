using NBautoFramework.Config;
using NBautoFramework.Helpers;

namespace NBautoFramework.Base
{
    /// <summary>
    /// Hook to Initialize the test.
    /// </summary>
    public class TestInitializeHook: BaseStep
    {
        /// <summary>
        /// Sets the settings to initialize the test.
        /// </summary>
        /// <param name="environment">The environment to perform the test.</param>
        protected static void InitializeSettings(string environment)
        {
            ConfigReader.SetFrameworkSettings(environment);
            if(Settings.IsToLog)
            {
                LogHelpers.CreateLogFile();
            }
            Browser.OpenBrowser(Settings.BrowserType);
        }
    }
}
