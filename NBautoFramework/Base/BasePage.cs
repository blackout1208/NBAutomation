using OpenQA.Selenium.Support.PageObjects;

namespace NBautoFramework.Base
{
    /// <summary>
    /// All the pages must have a constructor
    /// To allow the Driver to control them
    /// </summary>
    public abstract class BasePage : Base
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}