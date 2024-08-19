using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace MovieCatalog2;

[TestFixture]
public class MovieCatalogTests
{
    protected IWebDriver driver;
    private static readonly string BaseUrl = "http://moviecatalog-env.eba-ubyppecf.eu-north-1.elasticbeanstalk.com/";
    private static string? lastMovieTitle;
    private static string? lastMovieDescription;
    private Actions actions;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
        chromeOptions.AddArgument("--disable-search-engine-choice-screen");

        driver = new ChromeDriver(chromeOptions);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        // Initialize Actions instance
        actions = new Actions(driver);

        driver.Navigate().GoToUrl($"{BaseUrl}#login");

        var loginForm = driver.FindElement(By.XPath("//section[@id='login']"));
        actions = new Actions(driver);
        actions.MoveToElement(loginForm).Perform();

        var loginHere = driver.FindElement(By.XPath("//a[@href='/User/Login']"));
        loginHere.Click();

        var emailInput = driver.FindElement(By.XPath("//input[@id='form2Example17']"));
        var passWordInput = driver.FindElement(By.XPath("//input[@id='form2Example27']"));
        var logginButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
        emailInput.SendKeys("batdancho@bat.com");
        passWordInput.SendKeys("123456");
        logginButton.Click();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    private string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private void NavigateToLastPage()
    {
        // Find the pagination elements to navigate to the last page
        var paginationItems = driver.FindElements(By.CssSelector("ul.pagination li.page-item"));
        var lastPageItem = paginationItems.Last();
        actions.MoveToElement(lastPageItem).Perform();

        // Click the link of the actual last page
        var lastPageLink = lastPageItem.FindElement(By.CssSelector("a.page-link"));
        lastPageLink.Click();
    }

    private void VerifyLastMovieTitle(string expectedTitle)
    {
        // Re-locate the movie elements on the last page
        var movies = driver.FindElements(By.CssSelector(".col-lg-4"));
        var lastMovieElement = movies.Last();
        var lastMovieElementTitle = lastMovieElement.FindElement(By.CssSelector("h2"));

        // Verify that the last movie title matches the expected value
        string actualMovieTitle = lastMovieElementTitle.Text.Trim();
        Assert.That(actualMovieTitle, Is.EqualTo(expectedTitle), "The last movie title does not match the expected value.");
    }

    [Test,Order(1)]
    public void AddMovieWithoutTitleTest()
    {
        string invalidMovieTitle = "";

        // Navigate to the Add Movie page
        driver.Navigate().GoToUrl($"{BaseUrl}Catalog/Add");

        driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(invalidMovieTitle);
        var addButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
        actions.MoveToElement(addButton).Perform();
        addButton.Click();

        var messageElement = driver.FindElement(By.XPath("//div[@class='toast-message']"));
        Assert.That(messageElement.Text.Trim(), Is.EqualTo("The Title field is required."), "The title error message is not displayed as expected.");

    }
    [Test, Order(2)]
    public void AddMovieWithoutDescriptionTest()
    {
        lastMovieTitle = "TITLE " + GenerateRandomString(5);
        string invalidDescription = "";

        // Navigate to the Add Movie page
        driver.Navigate().GoToUrl($"{BaseUrl}Catalog/Add");

        driver.FindElement(By.XPath("//input[@name='Title']")).SendKeys(lastMovieTitle);
        driver.FindElement(By.XPath("//textarea[@id='form2Example17']")).SendKeys(invalidDescription);

        var addButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
        actions.MoveToElement(addButton).Perform();
        addButton.Click();

        var messageElement = driver.FindElement(By.XPath("//div[@class='toast-message']"));
        Assert.That(messageElement.Text.Trim(), Is.EqualTo("The Description field is required."), "The title error message is not displayed as expected.");

    }
    [Test, Order(3)]
    public void AddMovieWithRandomTitleTest()
    {
        
        lastMovieTitle = "TITLE " + GenerateRandomString(5);
        lastMovieDescription = "DESCRIPTION " + GenerateRandomString(5);

        // Navigate to the Add Movie page
        driver.Navigate().GoToUrl($"{BaseUrl}Catalog/Add");

        var titleInput = driver.FindElement(By.XPath("//input[@name='Title']"));
        var descriptionInput = driver.FindElement(By.XPath("//textarea[@id='form2Example17']"));
        titleInput.Clear();
        descriptionInput.Clear();
        titleInput.SendKeys(lastMovieTitle);
        descriptionInput.SendKeys(lastMovieDescription);

        var addButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
        actions.MoveToElement(addButton).Perform();
        addButton.Click();

        // Navigate to the last page of the movie listings
        NavigateToLastPage();

        VerifyLastMovieTitle(lastMovieTitle);
    }
    [Test,Order(4)]
    public void EditLastAddedMovieTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Catalog/All");
        NavigateToLastPage();

        // Re-locate the movie elements on the last page
        var movies = driver.FindElements(By.CssSelector(".col-lg-4"));
        var lastMovieElement = movies.Last();
        var lastMovieEditButton = lastMovieElement.FindElement(By.XPath("//a[@class='btn btn-outline-success']"));
        lastMovieEditButton.Click();

        lastMovieTitle = "CHANGED " + lastMovieTitle;
        var titleInput = driver.FindElement(By.XPath("//input[@name='Title']"));
        titleInput.Clear();
        titleInput.SendKeys(lastMovieTitle);

        var editButton = driver.FindElement(By.XPath("//button[@class='btn warning']"));
        actions.MoveToElement(editButton).Perform();
        editButton.Click();

        var messageElement = driver.FindElement(By.XPath("//div[@class='toast-message']"));
        Assert.That(messageElement.Text.Trim(), Is.EqualTo("The Movie is edited successfully!"), "The title error message is not displayed as expected.");
    }

    [Test, Order(5)]
    public void MarkLastAddedMovieAsWatchedTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Catalog/All#all");
        NavigateToLastPage();

        // Re-locate the movie elements on the last page
        var movies = driver.FindElements(By.CssSelector(".col-lg-4"));
        var lastMovieElement = movies.Last();
        var lastMovieMarkAsWatchedButton = lastMovieElement.FindElement(By.XPath("//a[@class='btn btn-info']"));
        lastMovieMarkAsWatchedButton.Click();

        driver.Navigate().GoToUrl($"{BaseUrl}Catalog/Watched#watched");

        NavigateToLastPage();
        VerifyLastMovieTitle(lastMovieTitle);

    }

    [Test, Order(6)]
    public void DeleteLastAddedMovieTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Catalog/All#all");
        NavigateToLastPage();
        var movies = driver.FindElements(By.CssSelector(".col-lg-4"));
        var lastMovieElement = movies.Last();
        var lastMovieDeleteButton = lastMovieElement.FindElement(By.XPath("//a[@class='btn btn-danger']"));
        lastMovieDeleteButton.Click();

        driver.FindElement(By.XPath("//button[@class='btn warning']")).Click();

        var messageElement = driver.FindElement(By.XPath("//div[@class='toast-message']"));

        Assert.That(messageElement.Text.Trim(), Is.EqualTo("The Movie is deleted successfully!"), "The movie was not deleted as expected.");

    }
}

