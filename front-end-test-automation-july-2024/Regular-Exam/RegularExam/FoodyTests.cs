using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace RegularExam;

public class FoodyTests
{
    protected IWebDriver driver;
    private static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";
    private static string? lastFoodTitle;
    private static string? lastFoodDescription;
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

        driver.Navigate().GoToUrl($"{BaseUrl}User/Login");

        var usernameInput = driver.FindElement(By.XPath("//input[@name='Username']"));
        var passWordInput = driver.FindElement(By.XPath("//input[@name='Password']"));
        var logginButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
        usernameInput.SendKeys("batdancho");
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


    [Test, Order(1)]
    public void AddFoodWithInvalidDataTest()
    {
        
        driver.Navigate().GoToUrl($"{BaseUrl}Food/Add");

        var addButton=driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
        addButton.Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Food/Add"), "The page should remain on the creation page with invalid data.");

        var mainErrorMsg = driver.FindElement(By.XPath("//li[contains(.,'Unable to add this food revue!')]"));
        Assert.That(mainErrorMsg.Text, Is.EqualTo("Unable to add this food revue!"));
    }

    [Test, Order(2)]
    public void AddRandomFoodTest()
    {
        lastFoodTitle = "TITLE " + GenerateRandomString(5);
        lastFoodDescription = "DESCRIPTION " + GenerateRandomString(5);

       
        driver.Navigate().GoToUrl($"{BaseUrl}Food/Add");


        var foodName = driver.FindElement(By.XPath("//input[@id='name']"));
        var foodDescription = driver.FindElement(By.XPath("//input[@id='description']"));

        foodName.SendKeys(lastFoodTitle);
        foodDescription.SendKeys(lastFoodDescription);

        var addButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
        addButton.Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}"), "The page link should be the homepage.");

        var footer = driver.FindElement(By.XPath("//footer[@class='py-5 bg-black mt-lg-5 ']"));
        actions.MoveToElement(footer).Perform();

        // Locate all food sections and get the last created food title
        var allFoods = driver.FindElements(By.XPath("//section[@id='scroll']"));
        var lastCreatedFoodTitle = allFoods.Last().FindElement(By.XPath(".//h2[@class='display-4']"));

        Assert.That(lastFoodTitle, Is.EqualTo(lastCreatedFoodTitle.Text));

    }
    [Test, Order(3)]
    public void EditLastAddedFoodTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}");
        var footer = driver.FindElement(By.XPath("//footer[@class='py-5 bg-black mt-lg-5 ']"));
        actions.MoveToElement(footer).Perform();

        // Locate all food sections and get the last one
        var allFoods = driver.FindElements(By.XPath("//section[@id='scroll']"));
        var lastFoodSection = allFoods.Last();

        var originalTitleElement = lastFoodSection.FindElement(By.XPath(".//h2[@class='display-4']"));
        var originalTitle = originalTitleElement.Text;

        var editButton = lastFoodSection.FindElement(By.XPath(".//a[contains(@href, '/Food/Edit')]"));
        editButton.Click();

        var editedTitle = "CHANGED NAME";
        var foodName = driver.FindElement(By.XPath("//input[@id='name']"));
        foodName.Clear();
        foodName.SendKeys(editedTitle);

        var addButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
        addButton.Click();

        footer = driver.FindElement(By.XPath("//footer[@class='py-5 bg-black mt-lg-5 ']"));
        actions.MoveToElement(footer).Perform();

        // Locate all food sections and get the last created food title
        allFoods = driver.FindElements(By.XPath("//section[@id='scroll']"));
        var lastCreatedFoodTitle = allFoods.Last().FindElement(By.XPath(".//h2[@class='display-4']"));

        Assert.That(originalTitle, Is.EqualTo(lastCreatedFoodTitle.Text));
    }

    [Test, Order(4)]
    public void SearchFoodTitleTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}");
        var seachedForTitle = lastFoodTitle;
        var searchField = driver.FindElement(By.XPath("//input[@name='keyword']"));
        searchField.SendKeys(seachedForTitle);

        var searchButton= driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"));
        searchButton.Click();

        var footer = driver.FindElement(By.XPath("//footer[@class='py-5 bg-black mt-lg-5 ']"));
        actions.MoveToElement(footer).Perform();

        // Locate all food sections and get the last created food title
        var allFoods = driver.FindElements(By.XPath("//section[@id='scroll']"));
        var lastCreatedFoodTitle = allFoods.Last().FindElement(By.XPath(".//h2[@class='display-4']"));

        Assert.That(seachedForTitle, Is.EqualTo(lastCreatedFoodTitle.Text));
        Assert.That(allFoods.Count, Is.EqualTo(1));
    }

    [Test, Order(5)]
    public void DeleteLastAddedFoodTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}");
        var footer = driver.FindElement(By.XPath("//footer[@class='py-5 bg-black mt-lg-5 ']"));
        actions.MoveToElement(footer).Perform();

        // Locate all food sections and get the last one
        var allFoods = driver.FindElements(By.XPath("//section[@id='scroll']"));
        var allFoodCountBeforeDeletion = allFoods.Count;

        var lastFoodSection = allFoods.Last();
        var originalTitleElement = lastFoodSection.FindElement(By.XPath(".//h2[@class='display-4']"));
        var originalTitle = originalTitleElement.Text;

        var deleteButton = lastFoodSection.FindElement(By.XPath(".//a[contains(@href, '/Food/Delete')]"));

        // Click the Delete button
        deleteButton.Click();

        footer = driver.FindElement(By.XPath("//footer[@class='py-5 bg-black mt-lg-5 ']"));
        actions.MoveToElement(footer).Perform();

        allFoods = driver.FindElements(By.XPath("//section[@id='scroll']"));
        var allFoodCountAfterDeletion = allFoods.Count;

        Assert.That(allFoodCountAfterDeletion, Is.EqualTo(allFoodCountBeforeDeletion - 1), "The food count should decrease by one after deletion.");

        var lastCreatedFoodTitle = allFoods.Last().FindElement(By.XPath(".//h2[@class='display-4']"));

        Assert.That(originalTitle, Is.Not.EqualTo(lastCreatedFoodTitle.Text));

    }
    [Test, Order(6)]
    public void SearchForDeletedFoodTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}");
        var seachedForTitle = lastFoodTitle;
        var searchField = driver.FindElement(By.XPath("//input[@name='keyword']"));
        searchField.SendKeys(seachedForTitle);

        var searchButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"));
        searchButton.Click();

        var footer = driver.FindElement(By.XPath("//footer[@class='py-5 bg-black mt-lg-5 ']"));
        actions.MoveToElement(footer).Perform();

        var errorMsg = driver.FindElement(By.XPath("//h2[@class='display-4'][contains(.,'There are no foods :(')]"));

        Assert.That(errorMsg.Text, Is.EqualTo("There are no foods :("));
        var addFoodButton = driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']"));
        Assert.That(addFoodButton.Displayed, Is.True, "The 'Add Food' button should be visible on the page.");

    }

}
