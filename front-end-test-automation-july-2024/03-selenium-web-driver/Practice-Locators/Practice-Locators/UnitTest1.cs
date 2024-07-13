using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace Practice_Locators
{
    public class Tests
    {
        private string baseUrl = "\\\\Mac\\Softuni\\front-end-test-automation-july-2024\\03-selenium-web-driver\\SimpleForm";
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var driver=new ChromeDriver();

        }
        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            /*
            driver.FindElements(By.Id("lname"));
            driver.FindElements(By.Id("newsletter"));
            driver.FindElements(By.Id("a"));
            driver.FindElements(By.Id("information"));

            driver.FindElement(By.LinkText("Softuni Official Page"));
            driver.FindElement(By.PartialLinkText("Official Page"));

            driver.FindElement(By.CssSelector("#fname"));
            driver.FindElement(By.CssSelector("input[name='fname]"));
            driver.FindElement(By.CssSelector("input[class*='button'"));
            driver.FindElement(By.CssSelector("div.additional-info > p >input[type='text']"));
            driver.FindElement(By.CssSelector("form div .additional-info input[type='text]"));

            driver.FindElement(By.XPath("//*[@id=\"lname\"]"));
            */
            var lName = driver.FindElements(By.Id("lname"));
            var lNameValue = lName.GetAttribute("value");


        }
    }
}