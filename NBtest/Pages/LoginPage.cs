using NBautoFramework.Base;
using NBautoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NBTest.Pages
{
    /// <summary>
    /// Login Page
    /// </summary>
    internal class LoginPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='loginUsernameForm']/label[2]/input")]
        private IWebElement _TxtUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='loginPasswordForm']/label[2]/input")]
        private IWebElement _TxtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "loginbtn")]
        private IWebElement _BtnLogin { get; set; }

        public void Login(string username, string password)
        {
            this._TxtUserName.SetText(username);
            this._TxtPassword.SetText(password);
        }

        public ProfileO_Default ClickLoginButton()
        {
            this._BtnLogin.NbSubmit();
            return this.GetInstance<ProfileO_Default>();
        }

        internal void IsPageLoaded()
        {
            this._TxtUserName.AssertElementPresent();
            this._TxtPassword.AssertElementPresent();
            this._BtnLogin.AssertElementPresent();
        }
    }
}
