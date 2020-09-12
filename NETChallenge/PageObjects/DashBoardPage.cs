using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace ClassLibrary1
{
    public class DashboardPage
    {
        IWebDriver driver;
        private WebDriverWait wait;
        IWebElement JiraLogo => driver.FindElement(By.Id("jira"));
        IWebElement CreateButton => driver.FindElement(By.Id("create_link"));
        IWebElement SummaryTextBox => wait.Until(driver => driver.FindElement(By.Id("summary")));
        IWebElement SprintDropDown => driver.FindElement(By.Id("customfield_10100-field"));
        IWebElement SendFormButton => driver.FindElement(By.Id("create-issue-submit"));
        IWebElement CreatedAlert => wait.Until(driver => driver.FindElement(By.ClassName("aui-message-success")));


        public DashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public bool LogoDisplayed()
        {
            return JiraLogo.Displayed;
        }

        public DashboardPage ClickCreateButton()
        {
            CreateButton.Click();
            return this;
        }

        public DashboardPage FillSummaryField(string summary)
        {
            SummaryTextBox.SendKeys(summary);
            return this;
        }

        public DashboardPage ExpandSprintDropDown()
        {

            SprintDropDown.Click();
            SprintDropDown.SendKeys(Keys.Enter);
            return this;
        }

        public DashboardPage SenndIssueForm()
        {
            SendFormButton.Click();
            return this;
        }

        public bool CreatedAlertDisplayed()
        {
            return CreatedAlert.Displayed;
        }

    }
}
