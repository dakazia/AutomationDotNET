using AutomationFramework.Utils;

namespace AutomationFramework
{
    internal class Run
    {
        public static void Main(string[] args)
        {

            BrowserFactory.Instance.Navigate().GoToUrl("https://cloud.google.com/products/calculator");

            BrowserFactory.Instance.Navigate().GoToUrl("https://www.google.com/");
        }
    }
}
