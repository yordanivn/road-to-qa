namespace WorkingWithiFrames;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class TestFrames
{

    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void TestFrameByIndex()
    {
        //wait until the iframe is available and switch to it by finding the first iframe
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

        //click the drop down button
        var dropDownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
        dropDownButton.Click();

        //select the links inside the dropdown menu
        var dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

        //verify and print the link texts
        foreach(var link in dropDownLinks)
        {
            Console.WriteLine(link.Text);
            Assert.IsTrue(link.Displayed, "Link inside the dropdown is not displayed as expected");
        }
        driver.SwitchTo().DefaultContent();
    }
    [Test]
    public void TestFrameById()
    {
        //wait until the iframe is available and switch to it by id
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));


        //click the drop down button
        var dropDownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
        dropDownButton.Click();

        //select the links inside the dropdown menu
        var dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

        // verify and print the link texts
        foreach (var link in dropDownLinks)
        {
            Console.WriteLine(link.Text);
            Assert.IsTrue(link.Displayed, "Link inside the dropdown is not displayed as expected");
        }
        driver.SwitchTo().DefaultContent();
    }
    [Test]
    public void TestFrameByWebElement()
    {
        //wait until the iframe is available and switch to it by id
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var frameElement= wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#result")));

        driver.SwitchTo().Frame(frameElement);

        //click the drop down button
        var dropDownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
        dropDownButton.Click();

        //select the links inside the dropdown menu
        var dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

        // verify and print the link texts
        foreach (var link in dropDownLinks)
        {
            Console.WriteLine(link.Text);
            Assert.IsTrue(link.Displayed, "Link inside the dropdown is not displayed as expected");
        }
        driver.SwitchTo().DefaultContent();
    }

}
