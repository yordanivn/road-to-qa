namespace SumTwoNumbers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Tests
{
    public IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void Test_AddTwoNumbers_ValidInput()
    {
        var calculatorPage = new SumNumberPage(driver);
        calculatorPage.OpenPage();
        var result = calculatorPage.AddNumbers("5","2");
        Assert.That(result,Is.EqualTo("Sum: 7"));
    }
    [Test]
    public void Test_AddTwoNumbers_InvalidInput()
    {
        var calculatorPage = new SumNumberPage(driver);
        calculatorPage.OpenPage();
        var result = calculatorPage.AddNumbers("sss", "aaa");
        Assert.That(result, Is.EqualTo("Sum: invalid input"));
    }
    [Test]
    public void Test_FormReset()
    {
        SumNumberPage calculatorPage = new SumNumberPage(driver);
        calculatorPage.OpenPage();
        var result = calculatorPage.AddNumbers("5", "2");
        Assert.That(result, Is.EqualTo("Sum: 7"));
        calculatorPage.ResetForm();
        Assert.True(calculatorPage.IsFormEmpty());
    }
}
