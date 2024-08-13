using System;
using OpenQA.Selenium;

namespace IdeaCenter.Pages
{
	public class MyIdeas:BasePage
	{
		public MyIdeas(IWebDriver driver):base(driver)
		{

		}
        public string url = BaseUrl + "/Ideas/MyIdeas";

		public IReadOnlyCollection<IWebElement> IdeaCards => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

		public IWebElement ViewButtonListIdea => IdeaCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Read')]"));

        public IWebElement EditButtonListIdea => IdeaCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Edit')]"));

		public IWebElement DeleteButtonListIdea => IdeaCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Delete')]"));

		public IWebElement DesctiptionLastIdea => IdeaCards.Last().FindElement(By.XPath(".//p[@class='card-text']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}

