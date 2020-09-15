using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Configuration;

namespace ClassLibrary
{
    public class LoginPage
    {
        private readonly string ConfigUsername = "andreancc";
           
        private readonly string ConfigPassword = "andreancc";
        IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement User => driver.FindElement(By.Id("login-form-username"));
        private IWebElement Password => driver.FindElement(By.Id("login-form-password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login"));



        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public LoginPage Username()
        {
            User.SendKeys(ConfigUsername);
            return this;
        }

        public LoginPage fillPassword()
        {
            Password.SendKeys(ConfigPassword);
            return this;
        }

        public LoginPage ClickLogin()
        {
            LoginButton.Click();
            return this;
        }
        public string FailedAccess()
        {
           var errormessage = driver.FindElement(By.Id("usernameerror")).Text;
           Console.WriteLine(errormessage);
           return errormessage;
        }


    }
}
