using System;
using NUnit.Framework.Interfaces;

namespace POM_Exercise.Tests
{
	public class InventoryTests:BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");
        }

        [Test]
		public void TestInventoryDisplay()
        {
            Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True,"The inventory page has no items displayed");
        }

        [Test]
        public void TestAddToCartByIndex()
        {
           inventoryPage.AddToCartByIndex(1);
           inventoryPage.ClickCartLink();
           Assert.That(cartPage.IsCartItemDispayed(), Is.True,"Cart item was not added to the cart"); 
        }

        [Test]
        public void TestPageTitle()
        {
            
            Assert.That(inventoryPage.IsPageLoaded(), Is.True);
        }


    }
}

