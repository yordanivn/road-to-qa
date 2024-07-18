using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace StudentRegistryApp.Pages
{
	public class ViewStudents:BasePage
	{
        public ViewStudents(IWebDriver driver) : base(driver)
		{
		}
		public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/students";
		public ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("body > ul > li"));

		public string[] GetStudnetsList()
		{
			var elementsStudnet = this.ListItemsStudents.Select(student => student.Text).ToArray();
			return elementsStudnet;
		}


    }
}

