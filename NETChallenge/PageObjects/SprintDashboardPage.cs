using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections;
namespace ClassLibrary


{
    public class SprintDashboardPage
    {


        IWebDriver driver;
        private WebDriverWait wait;
        IWebElement firstToDoSprintItem => wait.Until(driver => driver.FindElement(By.ClassName("ghx-issue-key-link")));
        IWebElement itemSprint => wait.Until(driver => driver.FindElement(By.ClassName("ghx-inner")));

        IWebElement inProgressColumn => wait.Until(driver => driver.FindElement(By.CssSelector(".ghx-columns > .ghx-column:nth-child(2)")));
        IWebElement sprintButton => wait.Until(driver => driver.FindElement(By.LinkText("Active sprints")));
        IWebElement firstInProgresstItem => wait.Until(driver => driver.FindElement(By.XPath("//*[@class='ghx-column ui-sortable'][2]/*[1]")));
        IWebElement doneColumn => wait.Until(driver => driver.FindElement(By.CssSelector(".ghx-columns > .ghx-column:nth-child(3)")));






        public SprintDashboardPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public SprintDashboardPage SelectActiveSprint()
        {
            sprintButton.Click();
         
            return this;
        }

        public SprintDashboardPage SelectFirstTicket()
        {
            Actions action = new Actions(driver);
            Thread.Sleep(500);
            action.ContextClick(itemSprint).SendKeys(Keys.ArrowUp).SendKeys(Keys.ArrowUp).SendKeys(Keys.ArrowUp).SendKeys(Keys.Enter).Perform();



            return this;
        }

        public SprintDashboardPage MoveToInProgress()
        {
            var ele1 = firstToDoSprintItem;
            var ele2 = inProgressColumn;
            var actions = new Actions(driver);
            actions.DragAndDrop(ele1, ele2).Perform();
            


            return this;
        }
        public int CountTicketsInProgress()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            int totalInProgressItems = driver.FindElements(By.XPath("//*[@class='ghx-column ui-sortable'][2]/div")).Count;
            Console.WriteLine(totalInProgressItems);



            return totalInProgressItems;
        }
        public int CountTicketsInDone()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            int totalDoneItems = driver.FindElements(By.XPath("//*[@class='ghx-column ui-sortable'][3]/div")).Count;
            Console.WriteLine(totalDoneItems);



            return totalDoneItems;
        }
        public SprintDashboardPage MoveToDone()
        {
            var ele1 = firstInProgresstItem;
            var ele2 = doneColumn;
            var actions = new Actions(driver);
            actions.DragAndDrop(ele1, ele2).Perform();
         
            return this;
        }

       

    }
}
