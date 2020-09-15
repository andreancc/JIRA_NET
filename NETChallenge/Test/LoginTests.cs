using ClassLibrary;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace JiraLoginTest
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
        public void LoginIn()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .Username()
                .fillPassword()
                .ClickLogin();
            //Thread.Sleep(5000);
            var jiraLogo = _driver.FindElementById("jira");
            Assert.IsTrue(jiraLogo.Displayed);
        }
        [Test]
        public void JiraDeniesAccess()
        {
            var loginPage = new LoginPage(_driver);
            loginPage
                .Username()
                .ClickLogin();

           // Thread.Sleep(5000);

            Assert.AreEqual(loginPage.FailedAccess(), "Sorry, your userid is required to answer a CAPTCHA question correctly.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
