using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace StudentRegistryApp.Pages
{
	public class AddStudent:BasePage
	{
		public AddStudent(IWebDriver driver):base(driver)
		{
		}
		public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";
		public IWebElement ElementErrorMsg => driver.FindElement(By.CssSelector("body > div"));
		public IWebElement NameField => driver.FindElement(By.XPath("//input[@id='name']"));
		public IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='email']"));
		public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit'][contains(.,'Add')]"));

		public void AddStudentForm(string name,string email)
		{
			this.NameField.SendKeys(name);
			this.EmailField.SendKeys(email);
			this.AddButton.Click();
		}

		public string GetErrorMsg()
		{
			return ElementErrorMsg.Text;
		}
    }
}

