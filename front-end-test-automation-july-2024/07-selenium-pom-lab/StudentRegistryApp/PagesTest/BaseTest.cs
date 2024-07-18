using System;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace StudentRegistryApp.PagesTest
{
	public class BaseTest
	{
		protected IWebDriver driver;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			driver = new ChromeDriver();
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}

