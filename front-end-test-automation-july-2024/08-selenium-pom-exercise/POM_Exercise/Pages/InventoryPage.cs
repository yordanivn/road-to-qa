using System;
using OpenQA.Selenium;

namespace POM_Exercise.Pages
{
	public class InventoryPage:BasePage
	{
		public InventoryPage(IWebDriver driver):base(driver)
		{
		}
		private readonly By cartLink = By.CssSelector(".shopping_cart_link");
		private readonly By productsTitle = By.ClassName("title");
		private readonly By inventoryItems = By.CssSelector(".inventory_item");

		public void AddToCartByIndex(int itemIndex)
		{
			var itemAddToCartButon = By.XPath($"//div[@class='inventory_list']//div[@class='inventory_item'][{itemIndex}]//button");
			Click(itemAddToCartButon);
		}

		public void AddToCartByName(string productName)
		{
			var itemAddToCartButon = By.XPath($"//div[text()='{productName}']" + $"/ancestor::div[@class='inventory_item']//button[contains(@class,'btn_inventory')]");
			Click(itemAddToCartButon);
        }

		public void ClickCartLink()
		{
			Click(cartLink);
		}

		public bool IsInventoryDisplayed()
		{
            return FindElements(inventoryItems).Any();
		}

		public bool IsPageLoaded()
		{
			return GetText(productsTitle) == "Products" && driver.Url.Contains("inventory.html");
		}

 	}
}

