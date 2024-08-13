using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using static System.Net.Mime.MediaTypeNames;

namespace RevueCrafters2;

public class Tests
{
    protected IWebDriver driver;
    private static readonly string BaseUrl = "https://d3s5nxhwblsjbi.cloudfront.net/";
    protected string lastCreatedRevueTitle="";
    protected string lastCreatedRevueDescription = "";

    [OneTimeSetUp]
    public void Setup()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
        chromeOptions.AddArgument("--disable-search-engine-choice-screen");

        driver = new ChromeDriver(chromeOptions);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        //login
        driver.Navigate().GoToUrl($"{BaseUrl}Users/Login#loginForm");
        var loginForm = driver.FindElement(By.Id("loginForm"));

        // Scroll to the login form using Actions class
        Actions actions = new Actions(driver);
        actions.MoveToElement(loginForm).Perform();

        var emailInput= driver.FindElement(By.XPath("//input[@id='form3Example3']"));
        var passwordInput= driver.FindElement(By.XPath("//input[@id='form3Example4']"));
        var loginButton= driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block mb-4']"));

        emailInput.SendKeys("batdancho@bat.com");
        passwordInput.SendKeys("123456");
        loginButton.Click();

}
    private string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test,Order(1)]
    public void CreateRevueWithInvalidDataTest()
    {
        string invalidRevueTittle = "";
        string invalidRevueRescription = "";

        driver.Navigate().GoToUrl($"{BaseUrl}Revue/Create#createRevue");

        var createForm = driver.FindElement(By.CssSelector("div.card-body.p-md-5"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(createForm).Perform();

        var revueTitle =driver.FindElement(By.XPath("//input[@id='form3Example1c']"));
        var revuePicture = driver.FindElement(By.XPath("//input[@id='form3Example3c']"));
        var revueDescription = driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
        var createButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        revueTitle.SendKeys(invalidRevueTittle);
        revuePicture.SendKeys("");
        revueDescription.SendKeys(invalidRevueRescription);
        createButton.Click();

        var mainErrorMsg = driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));
        var titleErrorMsg = driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];
        var descriptionErrorMsg = driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Revue/Create#createRevue"));

        Assert.That(mainErrorMsg.Text, Is.EqualTo("Unable to create new Revue!"));
        Assert.That(titleErrorMsg.Text, Is.EqualTo("The Title field is required."));
        Assert.That(descriptionErrorMsg.Text, Is.EqualTo("The Description field is required."));
    }

    [Test,Order(2)]
    public void CreateRandomRevueTest()
    {

        driver.Navigate().GoToUrl($"{BaseUrl}Revue/Create#createRevue");

        var createForm = driver.FindElement(By.CssSelector("div.card-body.p-md-5"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(createForm).Perform();

        var revueTitle = driver.FindElement(By.XPath("//input[@id='form3Example1c']"));
        var revuePicture = driver.FindElement(By.XPath("//input[@id='form3Example3c']"));
        var revueDescription = driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
        var createButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        lastCreatedRevueTitle = "Revue " + GenerateRandomString(5);
        lastCreatedRevueDescription = "Revue Description " + GenerateRandomString(5);

        revueTitle.SendKeys(lastCreatedRevueTitle);
        revuePicture.SendKeys("");
        revueDescription.SendKeys(lastCreatedRevueDescription);
        createButton.Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Revue/MyRevues#createRevue"),"The url is not correct");

        var RevuesCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

        //var ViewButtonLastRevue = RevuesCards.Last().FindElement(By.XPath(".//a[@class='btn btn-sm btn-outline-secondary' and text()='View']"));
        //var EditButtonLastRevue = RevuesCards.Last().FindElement(By.XPath(".//a[@class='btn btn-sm btn-outline-secondary' and text()='Edit']"));
        //var DeleteButtonLastRevue = RevuesCards.Last().FindElement(By.XPath(".//a[@class='btn btn-sm btn-outline-secondary' and text()='Delete']"));
        //var DescriptionLastRevue = RevuesCards.Last().FindElement(By.XPath(".//p[@class='card-text']"));
        var TitleLastRevue = RevuesCards.Last().FindElement(By.XPath(".//div[@class='text-muted text-center']"));

        Assert.That(lastCreatedRevueTitle, Is.EqualTo(TitleLastRevue.Text),"The titles does not match");
    }

    [Test, Order(3)]
    public void SearchRevueTittleTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Revue/MyRevues#myRevues");

        var allRevues = driver.FindElement(By.XPath("//div[@class='album py-5 bg-light']"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(allRevues).Perform();

        var searchInput = lastCreatedRevueTitle;

        var saerchRevueTitleField = driver.FindElement(By.XPath("//input[@id='keyword']"));
        var searchRevueButton = driver.FindElement(By.XPath("//button[@id='search-button']"));

        saerchRevueTitleField.SendKeys(searchInput);
        searchRevueButton.Click();

        var RevuesCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var TitleLastRevue = RevuesCards.Last().FindElement(By.XPath(".//div[@class='text-muted text-center']"));

        Assert.That(searchInput, Is.EqualTo(TitleLastRevue.Text)); ;
    }

    [Test,Order(4)]
    public void EditLastCreatedRevueTitleTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Revue/MyRevues#myRevues");

        var allRevues = driver.FindElement(By.XPath("//div[@class='album py-5 bg-light']"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(allRevues).Perform();

        var RevuesCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

        Assert.That(RevuesCards.Count, Is.GreaterThan(0));

        var EditButtonLastRevue = RevuesCards.Last().FindElement(By.XPath(".//a[@class='btn btn-sm btn-outline-secondary' and text()='Edit']"));
        EditButtonLastRevue.Click();

        //edit form
        var editForm = driver.FindElement(By.XPath("//div[@class='card-body p-md-5']"));
        actions.MoveToElement(editForm).Perform();

        var editedTitle = "Edited Title";
        var revueTitle = driver.FindElement(By.XPath("//input[@id='form3Example1c']"));
        revueTitle.Clear();
        revueTitle.SendKeys(editedTitle);
        var editButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));
        editButton.Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Revue/MyRevues"), "The url is not correct");

        RevuesCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        var TitleLastRevue = RevuesCards.Last().FindElement(By.XPath(".//div[@class='text-muted text-center']"));

        Assert.That(TitleLastRevue.Text, Is.EqualTo(editedTitle)); 
    }
    [Test, Order(5)]
    public void DeleteLastCreatedRevueTitleTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Revue/MyRevues#myRevues");

        var allRevues = driver.FindElement(By.XPath("//div[@class='album py-5 bg-light']"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(allRevues).Perform();

        var RevuesCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

        var RevueCardsBeforeDelete = RevuesCards;
        Assert.That(RevueCardsBeforeDelete.Count, Is.GreaterThan(0));

        var DeleteButtonLastRevue = RevuesCards.Last().FindElement(By.XPath(".//a[@class='btn btn-sm btn-outline-secondary' and text()='Delete']"));
        DeleteButtonLastRevue.Click();

        string currentUrl = driver.Url;
        Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Revue/MyRevues"), "The url is not correct");

        RevuesCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        Assert.That(RevuesCards.Count, Is.LessThan(RevueCardsBeforeDelete.Count));
        var TitleLastRevue = RevuesCards.Last().FindElement(By.XPath(".//div[@class='text-muted text-center']"));

        Assert.That(TitleLastRevue.Text, Is.Not.EqualTo(lastCreatedRevueTitle));

    }
    [Test,Order(6)]
    public void SearchDeletedOrNonExistentRevueTest()
    {
        driver.Navigate().GoToUrl($"{BaseUrl}Revue/MyRevues#myRevues");

        var allRevues = driver.FindElement(By.XPath("//div[@class='album py-5 bg-light']"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(allRevues).Perform();

        var searchInput = lastCreatedRevueTitle;

        var saerchRevueTitleField = driver.FindElement(By.XPath("//input[@id='keyword']"));
        var searchRevueButton = driver.FindElement(By.XPath("//button[@id='search-button']"));

        saerchRevueTitleField.SendKeys(searchInput);
        searchRevueButton.Click();

        var noRevuesMessage = driver.FindElement(By.XPath("//span[@class='col-12 text-muted']"));

        //var RevuesCards = driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
        //var TitleLastRevue = RevuesCards.Last().FindElement(By.XPath(".//div[@class='text-muted text-center']"));

        Assert.That(noRevuesMessage.Text, Is.EqualTo("No Revues yet!"));
    }


}
