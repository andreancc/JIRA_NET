using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Interactions;
namespace ClassLibrary1
{
    public class TicketInfomationPage
    {


        IWebDriver driver;
        private WebDriverWait wait;
        
        
        IWebElement assignButton => driver.FindElement(By.Id("assign-issue"));
        IWebElement assignMe => driver.FindElement(By.Id("assign-to-me-trigger"));
        IWebElement submitButton => driver.FindElement(By.Id("assign-issue-submit"));
        IWebElement ConfirmMessage => wait.Until(driver => driver.FindElement(By.CssSelector(".aui-message")));
        IWebElement commentButton => driver.FindElement(By.Id("opsbar-comment-issue_container"));
        IWebElement commentBody => wait.Until(driver => driver.FindElement(By.Id("comment")));
        IWebElement commentSubmit => driver.FindElement(By.Id("issue-comment-add-submit"));
        
       


        public TicketInfomationPage(IWebDriver driver, WebDriverWait wait)

        {
            this.driver = driver;
            this.wait = wait;
         
        }


        public TicketInfomationPage AssingButton()
        {
            assignButton.Click();
            return this;
        }
        public TicketInfomationPage AssignPerson()
        {
            Thread.Sleep(2000);
            assignMe.Click();
            
            submitButton.Click();

            return this;
        }
        public bool SubmitAlertDisplayed()
        {
            return ConfirmMessage.Displayed;
        }

        public TicketInfomationPage CommentTicket(string comment)
        {
            Thread.Sleep(2000);
            commentButton.Click();
            commentBody.SendKeys(comment);
            commentSubmit.Click();
           

            return this;
        }
        public bool FindComment(string comment)
        {

            if (driver.FindElement(By.XPath("//*[contains(text(),'" + comment + "')]")) != null)
            {
                return true;
            }

            return false;
        }
    }
}
