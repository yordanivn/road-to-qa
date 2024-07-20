using System;
using OpenQA.Selenium;

namespace POM_Exercise.Pages
{
	public class CartPage:BasePage
	{
		public CartPage(IWebDriver driver):base(driver)
		{
		}
		private readonly By cartItem = By.CssSelector(".cart_item");
		private readonly By checkoutButton = By.CssSelector("#checkout");

		public bool IsCartItemDispayed()
		{
			return FindElement(cartItem).Displayed;
		}

		public void ClickCheckout()
		{
			Click(checkoutButton);
		}


	}
}

