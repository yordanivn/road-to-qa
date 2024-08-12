using System;
using OpenQA.Selenium;
namespace IdeaCenter.Pages
{
	public class EditIdeaPage:BasePage
	{
		public EditIdeaPage(IWebDriver driver):base(driver)
		{
		}
        public string url = BaseUrl + "/Ideas/Edit";

        public IWebElement EditIdeaTitle => driver.FindElement(By.XPath("//input[@id='form3Example1c']"));
		public IWebElement EditIdeaDescription => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));
		public IWebElement EditIdeaButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

		
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
        }

    }
}

