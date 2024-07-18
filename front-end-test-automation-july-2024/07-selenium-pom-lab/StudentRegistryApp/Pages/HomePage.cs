using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace StudentRegistryApp.Pages
{
	public class HomePage:BasePage
	{
		public HomePage(IWebDriver driver):base(driver)
		{

		}
		public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/";
		public IWebElement ElementStudentCount => driver.FindElement(By.XPath("//p//b"));

		public int StudnetsCount()
		{
			string studnetsCountString = this.ElementStudentCount.Text;
			return int.Parse(studnetsCountString);

		}
    }
}

