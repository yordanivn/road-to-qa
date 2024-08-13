using System;
using OpenQA.Selenium;

namespace IdeaCenter.Pages
{
	public class CreateIdea:BasePage
	{
		public CreateIdea(IWebDriver driver):base(driver)
		{

		}

        public string url = BaseUrl + "/Ideas/Create";

		public IWebElement TitleInput => driver.FindElement(By.XPath("//input[@id='form3Example1c']"));

		public IWebElement ImageInput => driver.FindElement(By.XPath("//input[@id='form3Example3c']"));

		public IWebElement DescriptionInput => driver.FindElement(By.XPath("//textarea[@id='form3Example4cd']"));

		public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

		public IWebElement MainMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));

		public IWebElement TitleErrorMsg => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];

		public IWebElement DescriptionErrorMsg => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];


		public void CreateNewIdea(string title, string img, string description)
		{
			TitleInput.SendKeys(title);
			ImageInput.SendKeys(img);
			DescriptionInput.SendKeys(description);
			CreateButton.Click();
		}
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
        }

		public void AssertErrorMessages()
		{
			Assert.True(MainMessage.Text.Equals("Unable to create new Idea!"));
			Assert.True(TitleErrorMsg.Text.Equals("The Title field is required."));
			Assert.True(DescriptionErrorMsg.Text.Equals("The Description field is required."));
		}

        
    }
}

