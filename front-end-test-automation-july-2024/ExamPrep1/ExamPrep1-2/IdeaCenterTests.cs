using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace ExamPrep1_2;

public class IdeaCenterTests
{
    protected IWebDriver driver;
    private static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/";
    protected string lastCreatedIdeaTitle = "";
    protected string lastCreatedIdeaDescription = "";
    private Actions actions;

    [OneTimeSetUp]
    public void Setup()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
        chromeOptions.AddArgument("--disable-search-engine-choice-screen");

        driver = new ChromeDriver(chromeOptions);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        // Initialize Actions instance
        actions = new Actions(driver);

        driver.Navigate().GoToUrl($"{BaseUrl}Users/Login");
        var emailInput = driver.FindElement(By.XPath("//input[@name='Email']"));
        var passWordInput = driver.FindElement(By.XPath("//input[@name='Password']"));
        var logginButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']"));
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

    [Test, Order(1)]
    public void CreateIdeaWithInvalidDataTests()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Ideas/Create");
        var titleInput = driver.FindElement(By.XPath("//input[@name='Title']"));
        var descriptionInput = driver.FindElement(By.XPath("//textarea[@name='Description']"));

        var createIdeaButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));
        createIdeaButton.Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Ideas/Create"), "The page should remain on the creation page with invalid data.");

        var mainErrorMsg = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']"));
        var titleErrorMsg=driver.FindElements((By.XPath("//span[@class='text-danger field-validation-error']")))[0];
        var descriptionErrorMsg= driver.FindElements((By.XPath("//span[@class='text-danger field-validation-error']")))[1];

        Assert.That(mainErrorMsg.Text, Is.EqualTo("Unable to create new Idea!"));
        Assert.That(titleErrorMsg.Text, Is.EqualTo("The Title field is required."));
        Assert.That(descriptionErrorMsg.Text, Is.EqualTo("The Description field is required."));

    }
    [Test, Order(2)]
    public void CreateRandomIdeaTests()
    {
        lastCreatedIdeaTitle = "IDEA " + GenerateRandomString(5);
        lastCreatedIdeaDescription = "DESCRIPTION " + GenerateRandomString(5);

        driver.Navigate().GoToUrl($"{BaseUrl}Ideas/Create");
        var titleInput = driver.FindElement(By.XPath("//input[@name='Title']"));
        var descriptionInput = driver.FindElement(By.XPath("//textarea[@name='Description']"));
        titleInput.SendKeys(lastCreatedIdeaTitle);
        descriptionInput.SendKeys(lastCreatedIdeaDescription);

        var createIdeaButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));
        createIdeaButton.Click();

        
        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Ideas/MyIdeas"), "The page should redicrect to my ideas page");

        var footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        var allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaDescription = allIdeasCars.Last().FindElement(By.XPath(".//p[@class='card-text']"));

        Assert.That(lastIdeaDescription.Text, Is.EqualTo(lastCreatedIdeaDescription));
    }

    [Test, Order(3)]
    public void ViewLastCreatedIdeaTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");
        var footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        var allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaViewButton = allIdeasCars.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Read')]"));
        lastIdeaViewButton.Click();

        var title = driver.FindElement(By.XPath("//h1"));
        Assert.That(title.Text, Is.EqualTo(lastCreatedIdeaTitle));
    }

    [Test, Order(4)]
    public void EditLastCreatedIdeaTitleTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");
        var footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        var allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaEditButton = allIdeasCars.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Edit')]"));
        lastIdeaEditButton.Click();

        var chandedTitle = "Edited " + lastCreatedIdeaTitle;
        var titleInput = driver.FindElement(By.XPath("//input[@name='Title']"));
        titleInput.Clear();
        titleInput.SendKeys(chandedTitle);
        driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Ideas/MyIdeas"), "The page should redicrect to my ideas page");

        footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaViewButton = allIdeasCars.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Read')]"));
        lastIdeaViewButton.Click();

        var title = driver.FindElement(By.XPath("//h1"));
        Assert.That(title.Text, Is.EqualTo(chandedTitle));

    }
    [Test, Order(5)]
    public void EditLastCreatedIdeaDescriptionTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");
        var footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        var allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaEditButton = allIdeasCars.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Edit')]"));
        lastIdeaEditButton.Click();

        var chandedDescription = "Edited " + lastCreatedIdeaDescription;
        var descriptionInput = driver.FindElement(By.XPath("//textarea[@name='Description']"));
        descriptionInput.Clear();
        descriptionInput.SendKeys(chandedDescription);
        driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']")).Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Ideas/MyIdeas"), "The page should redicrect to my ideas page");

        footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaViewButton = allIdeasCars.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Read')]"));
        lastIdeaViewButton.Click();

        var description = driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']"));
        Assert.That(description.Text, Is.EqualTo(chandedDescription));

    }
    [Test, Order(6)]
    public void DeleteLastIdeaTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Ideas/MyIdeas");
        var footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        var allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaDeleteButton = allIdeasCars.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Delete')]"));
        lastIdeaDeleteButton.Click();

        footer = driver.FindElement(By.XPath("//footer"));
        actions.MoveToElement(footer).Perform();

        allIdeasCars = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var lastIdeaDescription = allIdeasCars.Last().FindElement(By.XPath(".//p[@class='card-text']"));

        Assert.That(lastCreatedIdeaDescription, Is.Not.EqualTo(lastIdeaDescription.Text));
    }
}
