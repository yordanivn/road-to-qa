using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudentRegistryApp.Pages
{
	public class BasePage
	{
		protected readonly IWebDriver driver;

		public BasePage(IWebDriver driver)
		{
			this.driver = driver;
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
		}
		public virtual string PageUrl { get; }

		public IWebElement LinkHomePage => driver.FindElement(By.XPath("//a[@href='/']"));
		public IWebElement LinkViewStudentPage => driver.FindElement(By.LinkText("View Students"));
        public IWebElement LinkAddStudent => driver.FindElement(By.LinkText("Add Student"));
        public IWebElement ElementPageHeading => driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
		{
			driver.Navigate().GoToUrl(this.PageUrl);
		}

		public bool IsOpen()
		{
			return driver.Url == this.PageUrl;
		}

		public string GetTitle()
		{
			return driver.Title;
		}

		public string GetPageHedingText()
		{
			return ElementPageHeading.Text;
		}
    }
}

