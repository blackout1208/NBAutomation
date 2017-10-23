//using NBautoFramework.Base;
//using NBautoFramework.Config;
//using NBautoFramework.Helpers;
//using NBTest.Pages;
//using TechTalk.SpecFlow;

//namespace NBTest.Steps
//{
//    [Binding]
//    internal class ExtendedSteps : BaseStep
//    {
//        [Given(@"I have navigated to the application")]
//        public void GivenIHaveNavigatedToTheApplication()
//        {
//            this.NavigateSite();
//            this.CurrentPage = this.GetInstance<HomePage>();
//        }

//        [Given(@"I Delete employee '(.*)' before I start running test")]
//        public static void GivenIDeleteEmployeeBeforeIStartRunningTest(string employeeName)
//        {
//            var query = "delete from Employees where Name = '"+ employeeName + "'";
//            //Settings.ApplicationCon.ExecuteQuery(query);
//        }

//        [Then(@"I click (.*) link")]
//        public void ThenIClickLink(string linkName)
//        {
//            //if (linkName == "login")
//            //{
//            //    this.CurrentPage = this.CurrentPage.As<HomePage>().ClickLogin();
//            //}
//            //else if (linkName == "employeeList")
//            //{
//            //    this.CurrentPage = this.CurrentPage.As<HomePage>().ClickEmployeeList();
//            //}
//        }

//        [Then(@"I click (.*) button")]
//        public void ThenIClickButton(string buttonName)
//        {
//            //if (buttonName == "login")
//            //{
//            //    this.CurrentPage = this.CurrentPage.As<LoginPage>().ClickLoginButton();
//            //}
//            //else if (buttonName == "createnew")
//            //{
//            //    this.CurrentPage = this.CurrentPage.As<EmployeeListPage>().ClickCreateNew();
//            //}
//            //else if (buttonName == "create")
//            //{
//            //    this.CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
//            //}
//        }
//    }
//}
