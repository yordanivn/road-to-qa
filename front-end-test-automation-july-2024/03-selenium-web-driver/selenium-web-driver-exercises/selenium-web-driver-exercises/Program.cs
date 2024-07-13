using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_web_driver_exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            Console.WriteLine("Main page title: "+driver.Title);

            var searchBox = driver.FindElement(By.Id("searchInput"));
            searchBox.Click();

            searchBox.SendKeys("Quality Assurance" + Keys.Enter);

            Console.WriteLine("Quality Assurance page title: " + driver.Title);

            driver.Quit();
            driver.Dispose();

        }
    }
}
