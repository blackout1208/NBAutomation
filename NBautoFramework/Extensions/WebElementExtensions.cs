using System;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;
using NBautoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace NBautoFramework.Extensions
{
    /// <summary>
    /// Extension the web element from IWebElement.
    /// </summary>
    public static class WebElementExtensions
    {
        /// <summary>
        /// Clicks the element
        /// </summary>
        /// <param name="element">Element to be clicked</param>
        public static void NbClick(this IWebElement element)
        {
            element.Click();
            DriverContext.Driver.WaitForPageLoaded(1000);
        }

        /// <summary>
        /// Submits the form
        /// </summary>
        /// <param name="element">Element to be clicked</param>
        public static void NbSubmit(this IWebElement element)
        {
            element.Submit();
            DriverContext.Driver.WaitForPageLoaded(5000);
        }

        /// <summary>
        /// Sets text to element.
        /// </summary>
        /// <param name="element">Web element</param>
        /// <param name="text">Value to be inserted</param>
        public static void SetText(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        /// <summary>
        /// Sets int value to element
        /// </summary>
        /// <param name="element">Web element</param>
        /// <param name="value">Value to be inserted</param>
        public static void SetValue(this IWebElement element, Int32 value)
        {
            element.SendKeys(value.ToString());
        }

        /// <summary>
        /// Gets first item from drop down list
        /// </summary>
        /// <param name="element">Drop Down list</param>
        /// <returns>The first item</returns>
        public static string GetSelectedDropDown(this IWebElement element)
        {
            return IsElementPresent(element)
                ? new SelectElement(element).AllSelectedOptions.First().ToString()
                : null;
        }

        /// <summary>
        /// Gets all elements from the selected options within the select list
        /// </summary>
        /// <param name="element">SelectedList</param>
        /// <returns>List of all items</returns>
        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            return IsElementPresent(element)
                ? new SelectElement(element).AllSelectedOptions : null;
        }

        /// <summary>
        /// Selects an option from drop down list by the text displayed.
        /// </summary>
        /// <param name="element">Drop down list</param>
        /// <param name="value">Value to be selected</param>
        public static void SelectDropDownListByText(this IWebElement element, string value)
        {
            if (IsElementPresent(element))
            {
                new SelectElement(element).SelectByText(value);
            }
        }

        /// <summary>
        /// Selects an option in drop down list by the value
        /// </summary>
        /// <param name="element">Drop down list</param>
        /// <param name="value">Value to be selected</param>
        public static void SelectDropDownListByValue(this IWebElement element, string value)
        {
            if (IsElementPresent(element))
            {
                new SelectElement(element).SelectByValue(value);
            }
        }

        /// <summary>
        /// To bind handler from mouse on an element
        /// </summary>
        /// <param name="element">The element to be 'hovered'</param>
        public static void Hover(this IWebElement element)
        {
            if (IsElementPresent(element))
            {
                new Actions(DriverContext.Driver).MoveToElement(element).Perform();
            }
        }

        /// <summary>
        /// Gets the text from a link.
        /// </summary>
        /// <param name="element">Hyperlink.</param>
        /// <returns>The text string of the link.</returns>
        public static string GetLinkText(this IWebElement element)
        {
            return IsElementPresent(element) ? element.Text : null;
        }

        /// <summary>
        /// Assures that the element is present on the page.
        /// </summary>
        /// <param name="element">Element to be searched on the page</param>
        /// <exception cref="Exception">To assure that the test fails while is looking for the element</exception>
        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
            {
                throw new Exception("Element Not Present Exception");
            }
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                if (element.Displayed)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}
