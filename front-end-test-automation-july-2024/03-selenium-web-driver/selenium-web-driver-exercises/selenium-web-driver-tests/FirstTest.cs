
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace FirstTest
{
    public class FirstTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [TearDown]
        public void TearDown() { 
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test1()
        {

            driver.Navigate().GoToUrl("https://nakov.com");
            var windowsTitle = driver.Title;
            Assert.That(windowsTitle.Contains("Svetlin Nakov - Svetlin Nakov – Official Web Site and Blog"));
            Console.WriteLine(windowsTitle);

            var searchLink = driver.FindElement(By.ClassName("smoothScroll"));
            Assert.That(searchLink.Text, Does.Contain("SEARCH"));
            Console.WriteLine(searchLink.Text);

            searchLink.Click();

            var searchField = driver.FindElement(By.Id("s"));
            var placeholderText = searchField.GetAttribute("placeholder");
            Assert.That(placeholderText, Is.EqualTo("Search this site"));




        }
    }
}