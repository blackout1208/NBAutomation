using NBautoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace NBautoFramework.Base
{
    /// <summary>
    /// The Base class to all pages
    /// </summary>
    public class Base : Steps
    {
        /// <summary>
        /// The property that allows to control the current page
        /// </summary>
        public BasePage CurrentPage
        {
            get
            {
                return (BasePage)ScenarioContext.Current["currentPage"];
            }

            set
            {
                ScenarioContext.Current["currentPage"] = value;
            }
        }

        /// <summary>
        /// The WebDriver.
        /// </summary>
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// To instance each page and to set the webdriver to control it
        /// </summary>
        /// <typeparam name="TPage">The page</typeparam>
        /// <returns>The page instanciated</returns>
        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            var pageInstance = new TPage()
            {
                Driver = DriverContext.Driver
            };

            PageFactory.InitElements(DriverContext.Driver, pageInstance);
            return pageInstance;
        }

        /// <summary>
        /// Method that will be associated to the CurrenPage property
        /// Will allow to have the full access to the page and its properties
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }

        /// <summary>
        /// Checks if the correct page was loaded
        /// </summary>
        /// <param name="url">Expected url</param>
        public void CheckPageLoaded(string url)
        {
            DriverContext.Driver.IsPageLoaded(url);
        }
    }
}
