using OpenQA.Selenium;

namespace NBautoFramework.Base
{
    /// <summary>
    /// The context of the WebDriver
    /// </summary>
    public static class DriverContext
    {
        /// <summary>
        /// The WebDriver
        /// </summary>
        public static IWebDriver Driver { get; set; }

        /// <summary>
        /// The Browser object.
        /// </summary>
        public static Browser Browser { get; set; }
    }
}
