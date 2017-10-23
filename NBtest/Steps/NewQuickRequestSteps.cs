using NBautoFramework.Base;
using NBautoFramework.Helpers;
using NBtest.Pages;
using NBTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NBtest.Steps
{
    /// <summary>
    /// New Quick Request Setps.
    /// </summary>
    [Binding]
    public class NewQuickRequestSteps : BaseStep
    {
        /// <summary>
        /// Logged in
        /// </summary>
        [When(@"Logged in")]
        public void WhenLoggedIn()
        {
            string[] colHeader = { "UserName", "Password" };
            string[] row = { "nb", "teste" };
            var table = new Table(colHeader);
            table.AddRow(row);
            this.Given("See the LoginPage opened");
            this.When("Write UserName and Password", table);
            this.Then("Click login button");
            this.Then("See the username");
        }

        /// <summary>
        /// See NewQuickRequest button on the entrance page
        /// </summary>
        [Given(@"See NewQuickRequest button on the entrance page")]
        public void GivenSeeNewQuickRequestButtonOnTheEntrancePage()
        {
            this.CurrentPage.As<ProfileO_Default>().CheckNewQuickRequestButton();
        }

        /// <summary>
        /// Click the NewQuickRequest button
        /// </summary>
        [Then(@"Click the NewQuickRequest button")]
        public void ThenClickTheNewQuickRequestButton()
        {
            this.CurrentPage = this.CurrentPage.As<ProfileO_Default>().ClickNewQuickRequestPage();
        }

        /// <summary>
        /// The Page is loaded
        /// </summary>
        [Given(@"The Page is loaded")]
        public void GivenThePageIsLoaded()
        {
            this.CurrentPage.As<NewQuickRequestPage>().IsPageLoaded();
        }

        /// <summary>
        /// Add location
        /// </summary>
        [Then(@"Add location")]
        public void ThenAddLocation()
        {
            this.CurrentPage = this.CurrentPage.As<NewQuickRequestPage>().SelectLocation();
            this.CurrentPage.As<SearchLocations>().IsPageLoaded();

            var table = this.CurrentPage.As<SearchLocations>().GetEmployeeList();
            HtmlTableHelper.ReadTable(table);
            HtmlTableHelper.PerformActionOnCell("2", "Localização", "Copa");
        }

        /// <summary>
        /// Write Problem/Necessity, Observations and Contact
        /// </summary>
        /// <param name="table"></param>
        [Then(@"Write Problem/Necessity, Observations and Contact")]
        public void ThenWriteProblemNecessityObservationsAndContact(Table table)
        {
            dynamic t = table.CreateDynamicInstance();
            this.CurrentPage.As<NewQuickRequestPage>().FillForm(t.ProblemNecessity.ToString(), t.Observation.ToString(), t.Contact.ToString());
        }

        /// <summary>
        /// Click confirm button
        /// </summary>
        [Then(@"Click confirm button")]
        public void ThenClickConfirmButton()
        {
            this.CurrentPage = this.CurrentPage.As<NewQuickRequestPage>().Submit();
        }

        /// <summary>
        /// Go to Home Page
        /// </summary>
        [Then(@"Go to Home Page")]
        public void ThenGoToHomePage()
        {
            this.CurrentPage.As<ProfileO_Default>().IsPageLoaded();
        }
    }
}
