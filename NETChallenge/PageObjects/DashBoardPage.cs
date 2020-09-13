using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace ClassLibrary1
{
    public class DashboardPage
    {
        IWebDriver driver;
        private WebDriverWait wait;
        IWebElement jiraLogo => wait.Until(driver => driver.FindElement(By.Id("jira")));
        IWebElement createButton => driver.FindElement(By.Id("create_link"));
        IWebElement issueTypeButton => wait.Until(driver => driver.FindElement(By.Id("issuetype-field")));
  
        IWebElement summaryTextBox => wait.Until(driver => driver.FindElement(By.Id("summary")));
        IWebElement sprintDropDown => driver.FindElement(By.Id("customfield_10100-field"));
        IWebElement sendFormButton => driver.FindElement(By.Id("create-issue-submit"));
        IWebElement createdAlert => wait.Until(driver => driver.FindElement(By.ClassName("aui-message-success")));


        public DashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public bool LogoDisplayed()
        {
            return jiraLogo.Displayed;
        }

        public DashboardPage ClickCreateButton()
        {
            createButton.Click();
            return this;
        }

        public DashboardPage IssueTypeButton(string type)
        {
            issueTypeButton.Click();
               issueTypeButton.SendKeys(type);
            issueTypeButton.SendKeys(Keys.Enter);

            return this;
        }
      
        public DashboardPage FillSummaryField(string summary)

        {
            summaryTextBox.Click();
            summaryTextBox.SendKeys(summary);
            return this;
        }

        public DashboardPage ExpandSprintDropDown()
        {

            sprintDropDown.Click();
            sprintDropDown.SendKeys(Keys.Enter);
            return this;
        }

        public DashboardPage SenndIssueForm()
        {
            sendFormButton.Click();
            return this;
        }

        public bool CreatedAlertDisplayed()
        {
            return createdAlert.Displayed;
        }

    }
}
