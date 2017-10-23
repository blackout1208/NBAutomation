using NBautoFramework.Base;
using NBTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NBTest.Steps
{
    /// <summary>
    /// Steps for the LoginPage
    /// </summary>
    [Binding]
    public class LoginPageSteps : BaseStep
    {
        /// <summary>
        /// See the LoginPage opened
        /// </summary>
        [Given(@"See the LoginPage opened")]
        public void GivenISeeTheLoginPageOpened()
        {
            this.CurrentPage = this.GetInstance<LoginPage>();
            this.CurrentPage.As<LoginPage>().IsPageLoaded();
        }

        /// <summary>
        /// Write UserName and Password
        /// </summary>
        /// <param name="table">A table data with all the information to be inserted</param>
        [When(@"Write UserName and Password")]
        public void WhenIEnterUserNameAndPassword(Table table)
        {
            dynamic t = table.CreateDynamicInstance();
            this.CurrentPage.As<LoginPage>().Login(t.UserName, t.Password);
        }

        /// <summary>
        /// Click login button
        /// </summary>
        [Then(@"Click login button")]
        public void ThenIClickLoginButton()
        {
            this.CurrentPage = this.CurrentPage.As<LoginPage>().ClickLoginButton();
        }

        /// <summary>
        /// See the username
        /// </summary>
        [Then(@"See the username")]
        public void ThenIShouldSeeTheUsername()
        {
            this.CurrentPage.As<ProfileO_Default>().IsPageLoaded();
        }
    }
}
