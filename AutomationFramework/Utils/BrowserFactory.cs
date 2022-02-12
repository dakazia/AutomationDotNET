using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationFramework.Utils
{
    class BrowserFactory
    {
        private static readonly ThreadLocal<IWebDriver> _webDriver = new();

        public static IWebDriver Instance => _webDriver.Value ?? SetUpBrowser();

        private static IWebDriver SetUpBrowser()
        {
            IWebDriver driver;
            switch (PropertiesReader.GetProperty("BrowserType", "Properties.xml"))
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new EdgeDriver();
                    break;
                default: throw new ArgumentException();
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(10000);
            _webDriver.Value = driver;
            return driver;
        }

        public static void CloseBrowser()
        {
            _webDriver.Value?.Quit();
            _webDriver.Value = null;
        }
    }
}