using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using POM_Exercise.Pages;

namespace POM_Exercise.Tests
{
	public class BaseTest
	{
		protected IWebDriver driver;
        
		protected LoginPage loginPage;
		protected InventoryPage inventoryPage;
		protected CartPage cartPage;
		protected CheckoutPage checkoutPage;
		protected HiddenMenuPage hiddenMenuPage;

		[SetUp]
		public void SetUp()
		{
			driver = new ChromeDriver();
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			loginPage = new LoginPage(driver);
			inventoryPage = new InventoryPage(driver);
			cartPage = new CartPage(driver);
			checkoutPage = new CheckoutPage(driver);
			hiddenMenuPage = new HiddenMenuPage(driver);
		}

		[TearDown]
		public void TearDown()
		{
			if (driver != null)
			{
				driver.Quit();
				driver.Dispose();
			}
		}

		protected void Login(string username,string password)
		{
			driver.Navigate().GoToUrl("https://www.saucedemo.com/");
			loginPage.LoginUser(username, password);
		}

	}
}

