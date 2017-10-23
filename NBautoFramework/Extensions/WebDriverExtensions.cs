using System;
using System.Diagnostics;
using System.Threading;
using NBautoFramework.Base;
using NBautoFramework.Config;
using OpenQA.Selenium;

namespace NBautoFramework.Extensions
{
    /// <summary>
    /// Extensions to WebDriver class from selenium
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Checks if the browser went into the expected page
        /// </summary>
        /// <param name="driver">Web Browser</param>
        /// <param name="url">Expected URL</param>
        /// <exception cref="Exception"></exception>
        public static void IsPageLoaded(this IWebDriver driver, string url)
        {
            var allUrl = Settings.Url + url.ToLowerInvariant();
            var urlNoAttr = DriverContext.Driver.Url.Split('?')[0].ToLowerInvariant();
            if (!urlNoAttr.Equals(allUrl))
            {
                throw new Exception("Page not loaded");
            }
        }

        /// <summary>
        /// Waits for page load by js
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="sleepThread">To open a thread and force the C# to wait. (miliseconds)</param>
        public static void WaitForPageLoaded(this IWebDriver driver, int? sleepThread)
        {
            if (sleepThread.HasValue)
            {
                Thread.Sleep((int) sleepThread);
            }

            driver.WaitForCondition(dri =>
            {
                var state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, 30);
        }

        /// <summary>
        /// To force the execution to wait for the given condition
        /// </summary>
        /// <param name="obj">TODO: TO WRITE COMMENT</param>
        /// <param name="condition">The given condition to force the execution to wait for.</param>
        /// <param name="timeOut">The time limit for the execution to wait for the condition.</param>
        /// <typeparam name="T">The data type of the comparation.</typeparam>
        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (Execute(obj))
                {
                    break;
                }
            }

            bool Execute(T arg)
            {
                try
                {
                    if (condition != null)
                    {
                        return condition(arg);
                    }

                    return false;
                }
                catch (Exception)
                {
                    //TODO: Add to Logs this error
                    return false;
                }
            }
        }

        /// <summary>
        /// Invoke a javascript function
        /// </summary>
        /// <param name="driver">WebDriver</param>
        /// <param name="script">Javascript script.</param>
        /// <returns>The result of the javascript script.</returns>
        public static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
