using NBautoFramework.Base;
using NBautoFramework.Extensions;
using NBtest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NBTest.Pages
{
    /// <summary>
    /// 
    /// </summary>
    internal class ProfileO_Default : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='ContentPlaceHolderMain_btnNewRequestQuick']")]
        private IWebElement _BtnNewQuickRequest { get; set; }

        internal void IsPageLoaded()
        {
            this.CheckPageLoaded("profile/o/default");
        }

        public void CheckNewQuickRequestButton()
        {
            this._BtnNewQuickRequest.AssertElementPresent();
        }

        public NewQuickRequestPage ClickNewQuickRequestPage()
        {

            this._BtnNewQuickRequest.NbClick();
            return this.GetInstance<NewQuickRequestPage>();
        }
    }
}
