using NBautoFramework.Base;
using NBautoFramework.Extensions;
using NBTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NBtest.Pages
{
    internal class NewQuickRequestPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='ContentPlaceHolderMain_btnLocatFrom']")]
        private IWebElement _BtnOpenSearchLocation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ContentPlaceHolderMain_txtfl_name']")]
        private IWebElement _TxtProblemsNecessities { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ContentPlaceHolderMain_rq_obs']")]
        private IWebElement _TxtObservations { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ContentPlaceHolderMain_rq_telef']")]
        private IWebElement _TxtContact { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ContentPlaceHolderMain_btnSave']")]
        private IWebElement _BtnConfirm { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ContentPlaceHolderMain_btnSave']")]
        private IWebElement _BtnCancel { get; set; }

        public void IsPageLoaded()
        {
            this._BtnOpenSearchLocation.AssertElementPresent();
            this._TxtProblemsNecessities.AssertElementPresent();
            this._TxtContact.AssertElementPresent();
            this._TxtObservations.AssertElementPresent();
            this._BtnCancel.AssertElementPresent();
            this._BtnConfirm.AssertElementPresent();

            this.CheckPageLoaded("Requests/NewQuick");
        }

        public void FillForm(string problemsNecessities, string observations, string contact)
        {
            this._TxtProblemsNecessities.SetText(problemsNecessities);
            this._TxtObservations.SetText(observations);
            this._TxtContact.SetText(contact);
        }

        public BasePage Submit()
        {
            this._BtnConfirm.NbClick();
            return this.GetInstance<ProfileO_Default>();
        }

        public SearchLocations SelectLocation()
        {
            this._BtnOpenSearchLocation.NbClick();

            return this.GetInstance<SearchLocations>();
        }
    }
}
