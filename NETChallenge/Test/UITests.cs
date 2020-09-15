using ClassLibrary;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Configuration;
using System.Threading;

namespace JiraAutomationTests
{
    [TestFixture]
    public class UITests
    {
        ChromeDriver _driver;
        private WebDriverWait _wait;
        private readonly string BaseUrl = "http://localhost:8080";

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver
            {
                Url = BaseUrl
            };
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
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
