namespace Selenium_Waits;

using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class SeleniumWaits
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test, Order(1)]
    public void SearchProducWithImplicitWait_ShouldAddToCart()
    {
        //fill the search field
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@name='keywords']")).SendKeys("keyboard");

        //click on the search icon
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@title=' Quick Find ']")).Click();

        try
        {
            //click on buy now link
            driver.FindElement(By.LinkText("Buy Now")).Click();

            //verify text
            Assert.IsTrue(driver.PageSource.Contains("keyboard"), "The product 'keyboard' was not found in the cart page.");
            Console.WriteLine("Scenario completed");

        }
        catch (Exception ex)
        {
            Assert.Fail("Unexpected exception: " + ex.Message);
        }
    }

    [Test,Order(2)]
    public void SearchProductWithImplicitWait_ShouldThrowElementException()
    {
        // fill the search field
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@name='keywords']")).SendKeys("junk");

        //click on the search icon
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@title=' Quick Find ']")).Click();

        try
        {
            //click on buy now link
            driver.FindElement(By.LinkText("Buy Now")).Click();
            Assert.IsTrue(driver.PageSource.Contains("There is no product that matches the search criteria."));
        }
        catch (NoSuchElementException ex)
        {
            //verify the exception for non-existing product
            Assert.Pass("Expected NoSuchElementException was thrown.");
            Console.WriteLine("Timeout- "+ex.Message);
        }
        catch(Exception ex)
        {
            Assert.Fail("Unexpected exception: " + ex.Message);
        }
    }
}
