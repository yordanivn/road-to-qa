using System;
using OpenQA.Selenium;
namespace IdeaCenter.Pages
{
	public class IdeasReadPage:BasePage
	{
        public IdeasReadPage(IWebDriver driver) : base(driver)
		{
		}
        public string url = BaseUrl + "/Ideas/Read";

		public IWebElement ideaTitle => driver.FindElement(By.XPath("//div//h1"));
		public IWebElement ideaDescription => driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']"));
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}

