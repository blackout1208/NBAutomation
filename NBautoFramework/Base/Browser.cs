using System;
using NBautoFramework.Config;
using NBautoFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace NBautoFramework.Base
{
    /// <summary>
    /// The Web Browser
    /// </summary>
    public class Browser
    {
        private readonly IWebDriver _Driver;

        public Browser(IWebDriver driver)
        {
            _Driver = driver;
        }

        /// <summary>
        /// Navigate to a URL
        /// </summary>
        /// <param name="url">The URL.</param>
        public static void GoToUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                DriverContext.Driver.Url = url;
            }
        }

        /// <summary>
        /// Action to open the Browser
        /// </summary>
        /// <param name="browserType">The type of Browser</param>
        public static void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory + Settings.DriversFolder);
                    break;
                case BrowserType.Edge:
                    DriverContext.Driver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory + Settings.DriversFolder);
                    break;
                case BrowserType.Ie:
                    DriverContext.Driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory + Settings.DriversFolder);
                    break;
                default:
                    LogHelpers.Write("Type of Browser not defined.");
                    break;
            }

            DriverContext.Browser = new Browser(DriverContext.Driver);
        }
    }

    /// <summary>
    /// Types of Browser
    /// </summary>
    public enum BrowserType
    {

        /// <summary>
        /// Google Chrome
        /// </summary>
        Chrome,

        /// <summary>
        /// Microsoft Edge
        /// </summary>
        Edge,

        /// <summary>
        /// Internet Explorer
        /// </summary>
        Ie
    }
}
