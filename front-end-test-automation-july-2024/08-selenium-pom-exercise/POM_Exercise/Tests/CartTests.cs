using System;
namespace POM_Exercise.Tests
{
	public class CartTests:BaseTest
	{
        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");
            inventoryPage.AddToCartByIndex(1);
            inventoryPage.ClickCartLink();
        }

        [Test]
        public void TestCartItemDisplayed()
        {
            Assert.That(cartPage.IsCartItemDispayed(), Is.True);
        }

        [Test]
        public void TestClickCheckout()
        {
            cartPage.ClickCheckout();
            Assert.True(checkoutPage.IsPageOpen(), "Not navigated to the checkout page");
        }
    }
}

