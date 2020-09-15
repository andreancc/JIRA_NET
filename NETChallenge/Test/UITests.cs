using ClassLibrary;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using OpenQA.Selenium;
using NETChallenge.PageObject;
using System.Configuration;




namespace JiraAutomationTests
{
    [TestFixture]
   // [Parallelizable(ParallelScope.All)]
    public class UITests
    {
       private IWebDriver _driver;
       
       private WebDriverWait _wait;

        private readonly string BaseUrl = "http://localhost:8080";
          

        [SetUp]
        public void SetUp()
        {
            _driver = BrowserFactory.InitiatetBrowser("Chrome");
            _driver.Url = BaseUrl;

            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 1000));
            var loginPage = new LoginPage(_driver);
            loginPage
                .Username()
                .fillPassword()
                .ClickLogin();
            Thread.Sleep(5000);

       }


        [Test]
        public void JiraAllowsToCreateANewStory()
        {
            Console.WriteLine(_driver);

            var dashboardPage = new DashboardPage(_driver, _wait);
            Assert.IsTrue(dashboardPage.LogoDisplayed());
            dashboardPage
                .ClickCreateButton()
                .IssueTypeButton("Story")
               
                .FillSummaryField("Story to test")
                .ExpandSprintDropDown()
                .SenndIssueForm();
            Assert.IsTrue(dashboardPage.CreatedAlertDisplayed());
        }
        [Test]
        public void JiraAllowsToCreateANewBug()
        {

            var dashboardPage = new DashboardPage(_driver, _wait);
            Assert.IsTrue(dashboardPage.LogoDisplayed());
            dashboardPage
                .ClickCreateButton()
                .IssueTypeButton("Bug")
                .FillSummaryField("Bug to test")
                //.ExpandSprintDropDown()
                .SenndIssueForm();
            Assert.IsTrue(dashboardPage.CreatedAlertDisplayed());
        }
        [Test]
        public void MoveTicketFromBacklogToSprint()
        {

            var backlogPage = new BacklogPage(_driver, _wait);
            backlogPage
                 .ClicProjectsButton()
                 .SelectProjectName()
                 .SelectBacklog();

 Assert.IsTrue(backlogPage.ConfirmationDisplayed());
        }



        [Test]
        public void AssignTicketToPerson()
        {
            var backlogPage = new BacklogPage(_driver, _wait);
            backlogPage
                 .ClicProjectsButton()
                 .SelectProjectName()
                 .SelectFirstTicket();

            var ticketInfomationPage = new TicketInfomationPage(_driver, _wait);
            ticketInfomationPage
                 .AssingButton()
                 .AssignPerson();

            Assert.IsTrue(ticketInfomationPage.SubmitAlertDisplayed());
        }

        [Test]
        public void MoveticketToInProgress()
        {
            var backlogPage = new BacklogPage(_driver, _wait);
            backlogPage
                 .ClicProjectsButton()
                 .SelectProjectName();
                 

            var sprintDashboardPage = new SprintDashboardPage(_driver, _wait);
            int columninprogressitems = sprintDashboardPage.CountTicketsInProgress();

            sprintDashboardPage
              .MoveToInProgress();

            

            Assert.LessOrEqual(columninprogressitems, sprintDashboardPage.CountTicketsInProgress());

        }

        [Test]
        public void MoveticketToDone()
        {
            var backlogPage = new BacklogPage(_driver, _wait);
            backlogPage
                 .ClicProjectsButton()
                 .SelectProjectName();


            var sprintDashboardPage = new SprintDashboardPage(_driver, _wait);
            int columnDoneitems = sprintDashboardPage.CountTicketsInDone();
            sprintDashboardPage

                 .MoveToDone();
            Assert.LessOrEqual(columnDoneitems, sprintDashboardPage.CountTicketsInDone());
        }
        [Test]
        public void AddCommentToTicket()
        {
            var backlogPage = new BacklogPage(_driver, _wait);
            backlogPage
                 .ClicProjectsButton()
                 .SelectProjectName();
                 

            var sprintDashboardPage = new SprintDashboardPage(_driver, _wait);
            sprintDashboardPage
                .SelectActiveSprint()
                .SelectFirstTicket();
            var ticketInfomationPage = new TicketInfomationPage(_driver, _wait);
            ticketInfomationPage
                .CommentTicket("nuevo comentario");
                
               Assert.IsTrue(ticketInfomationPage.FindComment("nuevo comentario"));
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
