using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System;

namespace ClassLibrary

{
    public class BacklogPage
    {

        IWebDriver driver;
        private WebDriverWait wait;

        IWebElement projectsButton => driver.FindElement(By.Id("browse_link"));
        IWebElement projectnameselector => wait.Until(driver => driver.FindElement(By.XPath("//a[contains(text(),'Test Project (TP)')]")));
        IWebElement backlogButton => wait.Until(driver => driver.FindElement(By.CssSelector(".agile-icon-plan")));
        IWebElement firstTicketBacklog => wait.Until(driver => driver.FindElement(By.CssSelector(".ghx-issues:nth-child(2) > .js-issue:nth-child(2) .ghx-row")));
        IWebElement sendToSprintButton => wait.Until(driver => driver.FindElement(By.Id("ghx-issue-ctx-action-send-to-sprint-1")));
        IWebElement confirmSend => wait.Until(driver => driver.FindElement(By.CssSelector(".button-panel-button")));
        IWebElement ConfimrMessage => wait.Until(driver => driver.FindElement(By.CssSelector(".aui-message")));






        public BacklogPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;

          
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
        public BacklogPage SelectSprint()
        {
            sendToSprintButton.Click();
            return this;
        }

        
        public BacklogPage SelectBacklog()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            
            backlogButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
           
            Actions action = new Actions(driver);
            action.ContextClick(firstTicketBacklog).SendKeys(Keys.ArrowDown).SendKeys(Keys.Enter).Perform();
            confirmSend.Click();
            
            return this;
        }
       
        public BacklogPage SelectFirstTicket()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            
            backlogButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            
            Actions action = new Actions(driver);
            action.ContextClick(firstTicketBacklog).SendKeys(Keys.Enter).Perform();
          
            return this;
        }
        public bool ConfirmationDisplayed()
        {
            return ConfimrMessage.Displayed;
        }


    }
}
