using System;
using OpenQA.Selenium;
using POM_Exercise.Pages;

namespace POM_Exercise
{
	public class HiddenMenuPage:BasePage
	{
		public HiddenMenuPage(IWebDriver driver):base(driver)
		{
		}
		private readonly By menuButton = By.CssSelector(".bm-burger-button");
		private readonly By logoutButton = By.Id("logout_sidebar_link");

		public void ClickMenuButton()
		{
			Click(menuButton);
		}
		public void ClickLogOutButton()
		{
			Click(logoutButton);
		}
		public bool IsMenuOpen()
		{
			return FindElement(logoutButton).Displayed;
		}
	}
}

