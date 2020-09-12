using ClassLibrary1;
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
        }

        [Test]
        public void JiraAllowsToTheUserLoginIn()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin();
            Thread.Sleep(5000);
            var jiraLogo = _driver.FindElementById("jira");
            Assert.IsTrue(jiraLogo.Displayed);
        }

        [Test]
        public void JiraAllowsToCreateANewStory()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .fillUsername()
                .fillPassword()
                .ClickLogin();
            Thread.Sleep(5000);
            var dashboardPage = new DashboardPage(_driver, _wait);
            Assert.IsTrue(dashboardPage.LogoDisplayed());
            dashboardPage
                .ClickCreateButton()
                .FillSummaryField("test")
                .ExpandSprintDropDown()
                .SenndIssueForm();
            Assert.IsTrue(dashboardPage.CreatedAlertDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}
