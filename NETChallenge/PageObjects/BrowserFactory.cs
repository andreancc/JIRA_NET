using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;




namespace NETChallenge.PageObject
{
    class BrowserFactory
    {
        private static IWebDriver driver;
        public static IWebDriver InitiatetBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                driver = new FirefoxDriver();
                    break;

                case "Chrome":

                    driver = new ChromeDriver();
                    break;
              
            }
            return driver;
        }



    }
}