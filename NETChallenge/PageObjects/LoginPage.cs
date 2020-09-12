using OpenQA.Selenium;
using System.Configuration;

namespace ClassLibrary1
{
    public class LoginPage
    {
        private readonly string ConfigUsername = "andreancc";
        private readonly string ConfigPassword = "andreancc";
        IWebDriver driver;
        private IWebElement Username => driver.FindElement(By.Id("login-form-username"));
        private IWebElement Password => driver.FindElement(By.Id("login-form-password"));
        private IWebElement LoguinButton => driver.FindElement(By.Id("login"));

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


    }
}
