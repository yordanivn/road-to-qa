using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SumTwoNumbers
{
	public class SumNumberPage
	{
		private readonly IWebDriver driver;

		public SumNumberPage(IWebDriver driver)
		{
			this.driver = driver;
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        // fork the app in your own replit profile
        //https://sum-numbers.softuniqa.repl.co

        const string PageUrl = "https://596b3964-29da-42c8-834d-5fa8d9ce06a6-00-1iwask1f7frbr.spock.replit.dev/";

        public IWebElement Field1 => driver.FindElement(By.XPath("//div[@class='row']//input[@name='number1']"));
		public IWebElement Field2 => driver.FindElement(By.XPath("//div[@class='row']//input[@name='number2']"));
		public IWebElement ButtonCalc => driver.FindElement(By.XPath("//div[@class='buttons-bar']//input[@id='calcButton']"));
		public IWebElement ResetButton => driver.FindElement(By.XPath("//div[@class='buttons-bar']//input[@id='resetButton']"));
		public IWebElement ElementResult => driver.FindElement(By.XPath("//div[@id='result']"));

		public void OpenPage()
		{
			driver.Navigate().GoToUrl(PageUrl);

		}

		public string AddNumbers(string num1, string num2)
		{
			Field1.SendKeys(num1);
			Field2.SendKeys(num2);
			ButtonCalc.Click();
			string result = ElementResult.Text;
			return result;
		}

		public void ResetForm()
		{
			ResetButton.Click();
		}

		public bool IsFormEmpty()
		{
			return Field1.Text + Field2.Text + ElementResult.Text == "";
		}

		
    }
}

