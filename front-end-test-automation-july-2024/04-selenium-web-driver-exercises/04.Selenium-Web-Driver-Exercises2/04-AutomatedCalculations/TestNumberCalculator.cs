using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace _04_AutomatedCalculations;
[TestFixture]
public class TestCalculator
{
    private IWebDriver driver;
    IWebElement number1;
    IWebElement number2;
    IWebElement dropDownOperation;
    IWebElement calcBtn;
    IWebElement resetBtn;
    IWebElement divResult;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");

        number1 = driver.FindElement(By.Id("number1"));
        number2 = driver.FindElement(By.Id("number2"));
        dropDownOperation = driver.FindElement(By.Id("operation"));
        calcBtn = driver.FindElement(By.Id("calcButton"));
        resetBtn = driver.FindElement(By.Id("resetButton"));
        divResult = driver.FindElement(By.Id("result"));

    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    public void PerformCalculation(string firstNumber,string operation,string secondNumber,string expectedResult)
    {
        resetBtn.Click();
        if(!string.IsNullOrEmpty(firstNumber))
        {
            number1.SendKeys(firstNumber);
        }
        if (!string.IsNullOrEmpty(secondNumber))
        {
            number2.SendKeys(secondNumber);
        }
        if (!string.IsNullOrEmpty(operation))
        {
            new SelectElement(dropDownOperation).SelectByText(operation);
        }

        calcBtn.Click();
        Assert.That(divResult.Text, Is.EqualTo(expectedResult));
    }

    [Test]
    [TestCase("5","+ (sum)","10","Result: 15")]
    [TestCase("5", "+ (sum)", "-10", "Result: -5")]
    [TestCase("-5", "+ (sum)", "10", "Result: -5")]
    [TestCase("-5", "+ (sum)", "-10", "Result: -15")]
    [TestCase("1.5", "+ (sum)", "1.2", "Result: 1.7")]

    [TestCase("5", "- (subtract)", "2", "Result: 3")]
    [TestCase("5", "- (subtract)", "10", "Result: -5")]
    [TestCase("1.7", "- (subtract)", "1.2", "Result: 0.5")]

    [TestCase("5", "* (multiply)", "10", "Result: 50")]
    [TestCase("-5", "* (multiply)", "-10", "Result: 50")]
    [TestCase("-5", "* (multiply)", "10", "Result: -50")]
    [TestCase("5", "* (multiply)", "-10", "Result: -50")]
    [TestCase("5", "* (multiply)", "0", "Result: 0")]
    [TestCase("0", "* (multiply)", "10", "Result: 0")]
    [TestCase("1.2", "* (multiply)", "1.2", "Result: 1.44")]

    [TestCase("10", "/ (devide)", "2", "Result: 5")]
    [TestCase("-10", "/ (devide)", "2", "Result: -5")]
    [TestCase("10", "/ (devide)", "-2", "Result: 5")]
    [TestCase("2.4", "/ (devide)", "1.5", "Result: 1.6")]
    [TestCase("10", "/ (devide)", "0", "Result: Infinity")]

    [TestCase("invalid", "+ (sum)", "10", "Result: invalid input")]
    [TestCase("5", "+ (sum)", "invalid", "Result: invalid input")]
    public void TestNumberCalculator(string firstNumber, string operation, string secondNumber, string expectedResult)
    {
        
    }
}
