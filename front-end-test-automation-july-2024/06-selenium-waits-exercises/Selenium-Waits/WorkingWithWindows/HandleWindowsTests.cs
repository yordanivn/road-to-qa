namespace WorkingWithWindows;

using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class HandleWindowsTests
{
    IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
    [Test,Order(1)]
    public void HandleMulltipleWindows()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
        driver.FindElement(By.LinkText("Click Here")).Click();

        //get all windows handles
        ReadOnlyCollection<string> windowHandlers = driver.WindowHandles;

        //ensure there are at least two windows open
        Assert.That(windowHandlers.Count, Is.EqualTo(2), "There should be two windows open");

        //switch to the new windows
        driver.SwitchTo().Window(windowHandlers[1]);

        //verify the content of the new window
        string newWindowsContent = driver.PageSource;
        Assert.IsTrue(newWindowsContent.Contains("New Window"), "The content of the new window is not as expected");

        //log the content of the new window
        string path = Path.Combine(Directory.GetCurrentDirectory(), "window.txt");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        File.AppendAllText(path, "Window handle for new window: " + driver.CurrentWindowHandle + "\n\n");
        File.AppendAllText(path, "The page contet: " + newWindowsContent + "\n\n");

        driver.Close();

        //switch to the main window
        driver.SwitchTo().Window(windowHandlers[0]);

        //verify th econent of the original windows
        string originalWindowContet = driver.PageSource;
        Assert.IsTrue(originalWindowContet.Contains("Opening a new window"), "The content of the original windows is not as expected");

        //log the content of the original window
        File.AppendAllText(path, "Window handle for original window: " + driver.CurrentWindowHandle + "\n\n");
        File.AppendAllText(path, "The page content: " + originalWindowContet + "\n\n");
    }
    [Test,Order(2)]
    public void HandleNoSuchWindowException()
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
        driver.FindElement(By.LinkText("Click Here")).Click();

        //get all windows handles
        ReadOnlyCollection<string> windowHandlers = driver.WindowHandles;

        //ensure there are at least two windows open
        Assert.That(windowHandlers.Count, Is.EqualTo(2), "There should be two windows open");

        //switch to the new windows
        driver.SwitchTo().Window(windowHandlers[1]);

        driver.Close();

        try
        {
            //attempt to switch back to the close window
            driver.SwitchTo().Window(windowHandlers[1]);
        }
        catch(NoSuchWindowException ex)
        {
            //log the exception
            string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
            File.AppendAllText(path, "NoSuchWindowException caught: " + ex.Message + "\n\n");
            Assert.Pass("NoSuchWindowException was correctly handled.");
        }
        catch(Exception ex)
        {
            Assert.Fail("An unexpected exception was thrown: " + ex.Message);
        }
        finally
        {
            //swich back to the original window
            driver.SwitchTo().Window(windowHandlers[0]);
        }

    }
}
