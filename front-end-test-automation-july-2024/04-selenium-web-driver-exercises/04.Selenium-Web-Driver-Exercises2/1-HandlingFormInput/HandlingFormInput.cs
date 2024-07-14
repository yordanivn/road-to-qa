using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _1_HandlingFormInput;

public class HandlingFormInput
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void HandlingInput()
    {
        driver.FindElement(By.XPath("//span[@class='ui-button-text'][contains(.,'My Account')]")).Click();
        driver.FindElement(By.XPath("//span[@class='ui-button-text'][contains(.,'Continue')]")).Click();
        driver.FindElement(By.XPath("//input[@type='radio'][@value='m']")).Click();
        driver.FindElement(By.XPath("//input[contains(@name,'firstname')]")).SendKeys("Alf");
        driver.FindElement(By.XPath("//input[contains(@name,'lastname')]")).SendKeys("Fonso");
        driver.FindElement(By.Id("dob")).SendKeys("10/10/2010");

        Random rnd = new Random();
        int number = rnd.Next(1000, 9999);
        string email = "alfich" + number.ToString() + "@gmail.com";
        driver.FindElement(By.XPath("//input[contains(@name,'email_address')]")).SendKeys(email);

        driver.FindElement(By.XPath("//input[contains(@name,'company')]")).SendKeys("Softuni");
        driver.FindElement(By.XPath("//input[contains(@name,'street_address')]")).SendKeys("Vitosha bvl");
        driver.FindElement(By.XPath("//input[contains(@name,'postcode')]")).SendKeys("1111");
        driver.FindElement(By.XPath("//input[contains(@name,'city')]")).SendKeys("Sofia");
        driver.FindElement(By.XPath("//input[contains(@name,'state')]")).SendKeys("Sofia");

        new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");
        driver.FindElement(By.XPath("//input[contains(@name,'telephone')]")).SendKeys("0878964587");

        driver.FindElement(By.XPath("//input[contains(@name,'newsletter')]")).Click();


        driver.FindElement(By.XPath("//input[contains(@name,'password')]")).SendKeys("secret_password");
        driver.FindElement(By.XPath("//input[contains(@name,'confirmation')]")).SendKeys("secret_password");

        driver.FindElement(By.XPath("//span[@class='ui-button-text'][contains(.,'Continue')]")).Click();

        Assert.AreEqual(driver.FindElement(By.XPath("//div[@id='bodyContent']//h1")).Text, "Your Account Has Been Created!");

        driver.FindElement(By.XPath("//span[@class='ui-button-text'][contains(.,'Log Off')]")).Click();
        driver.FindElement(By.XPath("//span[@class='ui-button-text'][contains(.,'Continue')]")).Click();
        Console.WriteLine("User account created with email: "+email);
    }
}
