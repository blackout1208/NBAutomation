using NBautoFramework.Base;
using NBautoFramework.Config;
using NBautoFramework.Helpers;
using NBtest.ServiceReference;
using TechTalk.SpecFlow;

namespace NBTest.Hooks
{

    /// <summary>
    /// The initializer of the test
    /// </summary>
    [Binding]
    public class HookInitializer : TestInitializeHook
    {
        private static ServicesClient _Client;
        public HookInitializer()
        {
            _Client = new ServicesClient();
        }

        /// <summary>
        /// Sets all the settings to start each test
        /// </summary>
        [BeforeTestRun]
        public static void TestInitialize()
        {
            InitializeSettings("dev");
            Settings.DbConnection = Settings.DbConnection.DBconnect(Settings.DbConnectionString);
            _Client = new ServicesClient();
            _Client.CreateTestCycle("NBTest", "DUARTE", "CARLOS", "1.0", "1.0", "Windows 10");

            NavigateSite();
        }

        /// <summary>
        /// Execution after each step
        /// </summary>
        [AfterStep]
        public void AfterEachStep()
        {
            var stepName = ScenarioContext.Current.StepContext.StepInfo.Text;
            var featureName = FeatureContext.Current.FeatureInfo.Title;
            var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;

            if (ScenarioContext.Current.TestError != null)
            {
                _Client.WriteTestResult(featureName, scenarioName, stepName,
                    ScenarioContext.Current.TestError.StackTrace, "FAILED");
            }
            else
            {
                _Client.WriteTestResult(featureName, scenarioName, stepName, "", "PASSED");
            }
        }

        /// <summary>
        /// Navigation to the website.
        /// </summary>
        private static void NavigateSite()
        {
            Browser.GoToUrl(Settings.Url);
            LogHelpers.Write("Opened the Browser !!!");
        }

        /// <summary>
        /// Stops the test
        /// </summary>
        [AfterScenario]
        public static void TestStop()
        {
            //DriverContext.Driver.Quit();
        }
    }
}
