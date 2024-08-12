using System;
using IdeaCenter.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace IdeaCenter.Tests
{
	public class BaseTest
	{
		public IWebDriver driver;
		public LoginPage loginPage;
		public CreateIdea createIdeaPage;
		public MyIdeas myIdeasPage;
		public IdeasReadPage ideasReadPage;
		public EditIdeaPage editIdeaPage;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			chromeOptions.AddArgument("--disable-search-engine-choice-screen");

			driver = new ChromeDriver(chromeOptions);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			loginPage = new LoginPage(driver);
			loginPage.OpenPage();
			loginPage.Login("batdancho@bat.com", "123456");

			createIdeaPage = new CreateIdea(driver);
			myIdeasPage = new MyIdeas(driver);
			ideasReadPage = new IdeasReadPage(driver);
			editIdeaPage = new EditIdeaPage(driver);
		

		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}

        protected static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

