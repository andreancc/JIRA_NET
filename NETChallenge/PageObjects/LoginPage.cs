using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ClassLibrary1
{
    public class LoginPage
    {
        private readonly string ConfigUsername = "andreancc";
        private readonly string ConfigPassword = "andreancc";
        IWebDriver driver;
        private WebDriverWait wait;
        private IWebElement Username => driver.FindElement(By.Id("login-form-username"));
        private IWebElement Password => driver.FindElement(By.Id("login-form-password"));
        private IWebElement LoguinButton => driver.FindElement(By.Id("login"));
        private IWebElement loginError => wait.Until(driver => driver.FindElement(By.Id("usernameerror")));
        

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public LoginPage fillUsername()
        {
            Username.SendKeys(ConfigUsername);
            return this;
        }

        public LoginPage fillPassword()
        {
            Password.SendKeys(ConfigPassword);
            return this;
        }

        public LoginPage ClickLogin()
        {
            LoguinButton.Click();
            return this;
        }
        public string FailedAccess()
        {
           var errormessage = driver.FindElement(By.Id("usernameerror")).Text;
           Console.WriteLine(test);
           return errormessage;
        }


    }
}
