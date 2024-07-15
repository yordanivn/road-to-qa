namespace Selenium_Waits;

using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class ExplicitWaits
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
    public void SearchProducWithExplicitWait_ShouldAddToCart()
    {

        //fill the search field
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@name='keywords']")).SendKeys("keyboard");

        //click on the search icon
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@title=' Quick Find ']")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
       

        try
        {
            //create WebDriverWait object with timeout set to 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //wait to indentify the buy link using the LinkText property
            IWebElement buyNowLink = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            buyNowLink.Click();

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
    public void SearchProductWithExplicittWait_ShouldThrowElementException()
    {
        // fill the search field
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@name='keywords']")).SendKeys("junk");

        //click on the search icon
        driver.FindElement(By.XPath("//form[@name='quick_find']//input[@title=' Quick Find ']")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

        try
        {
            //create WebDriverWait object with timeout set to 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //wait to indentify the buy link using the LinkText property
            IWebElement buyNowLink = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

            //if found, fail the test as it should not exist
            buyNowLink.Click();
            Assert.Fail("The 'Buy Now' link was found for a non-existing product");

            Assert.IsTrue(driver.PageSource.Contains("There is no product that matches the search criteria."));
        }
        catch (WebDriverTimeoutException)
        {
            //expected exception for non-existing product
            Assert.Pass("Expected WebDriverTimeOutException was thrown.");
        }
        catch(Exception ex)
        {
            Assert.Fail("Unexpected exception: " + ex.Message);
        }
        finally
        {
            //reset the implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
