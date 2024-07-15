namespace WorkingWithAlerts;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

public class WorkingWithAlertsTests
{
    IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }
    [TearDown]
    public void TearDown()
    {
        driver.Close();
        driver.Dispose();
    }
    [Test]
    public void HandleBasicsAlerts()
    {
        //click on the "click for JS alert" button
        driver.FindElement(By.XPath("//button[@onclick='jsAlert()']")).Click();

        //switch to the alert
        IAlert alert = driver.SwitchTo().Alert();

        //verify the alert text
        Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"), "Alert text is not as expected");

        //acept the alert
        alert.Accept();

        //verify the result
        var resultElement = driver.FindElement(By.XPath("//p[@id='result']"));
        Assert.That(resultElement.Text, Is.EqualTo("You successfully clicked an alert"));
    }
    [Test]
    public void HandleConfirmAlert()
    {
        //click on the "click for JS alert" button
        driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();

        IAlert alert = driver.SwitchTo().Alert();

        //verify the alert text
        Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"), "Alert text is not as expected");

        alert.Accept();

        var resultElement = driver.FindElement(By.XPath("//p[@id='result']"));
        Assert.That(resultElement.Text, Is.EqualTo("You clicked: Ok"));

        driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();
        driver.SwitchTo().Alert();
        alert.Dismiss();

        resultElement = driver.FindElement(By.XPath("//p[@id='result']"));
        Assert.That(resultElement.Text, Is.EqualTo("You clicked: Cancel"));
    }
    [Test]
    public void HandlePromptAlert()
    {
        //click on the "click for JS alert" button
        driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();

        IAlert alert = driver.SwitchTo().Alert();

        //verify the alert text
        Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"), "Alert text is not as expected");

        //send text to the alert
        string inputText = "Hello";
        alert.SendKeys(inputText);

        alert.Accept();

        var resultElement = driver.FindElement(By.XPath("//p[@id='result']"));
        Assert.That(resultElement.Text, Is.EqualTo("You entered: " + inputText));
    }

}
