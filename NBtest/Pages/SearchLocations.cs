using NBautoFramework.Base;
using NBautoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NBtest.Pages
{
    class SearchLocations : BasePage
    {

        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolderMain_SearchLocations_grdLocation")]
        private IWebElement _TblLocationList { get; set; }

        public void IsPageLoaded()
        {
            this._TblLocationList.AssertElementPresent();
        }

        public IWebElement GetEmployeeList()
        {
            return this._TblLocationList;
        }


    }
}
