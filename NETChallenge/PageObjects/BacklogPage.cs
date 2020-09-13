using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ClassLibrary1

{
    public class BacklogPage
    {

        IWebDriver driver;
        private WebDriverWait wait;
        IWebElement jiraLogo => wait.Until(driver => driver.FindElement(By.Id("jira")));
        IWebElement projectsButton => driver.FindElement(By.Id("browse_link"));
        IWebElement projectnameselector => wait.Until(driver => driver.FindElement(By.XPath("xpath=//a[contains(text(),'Test Project (TP)')]")));
       

        public BacklogPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public bool LogoDisplayed()
        {
            return jiraLogo.Displayed;
        }

        public BacklogPage ClicProjectsButton()
        {
            projectsButton.Click();
            return this;
        }

        public BacklogPage SelectProjectName()
        {
            projectnameselector.Click();
            return this;
        }
    }
}
