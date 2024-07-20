using System;
namespace POM_Exercise.Tests
{
	public class CheckoutTests:BaseTest
	{
        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");
            inventoryPage.AddToCartByIndex(1);
            inventoryPage.ClickCartLink();
            cartPage.ClickCheckout();
        }

        [Test]
        public void TestCheckoutPageLoaded()
        {
            Assert.That(checkoutPage.IsPageOpen(), Is.True,"The checkout page was not open");
        }

        [Test]
        public void TestContinueToNextStep()
        {
            checkoutPage.CheckOutDetails("ala", "bala", "1000");
            Assert.That(checkoutPage.IsPageOpen(), Is.True, "The checkout page was not open");
        }

        [Test]
        public void TestCompleteOrder()
        {
            checkoutPage.CheckOutDetails("ala", "bala", "1000");
            checkoutPage.ClickFinish();
            Assert.That(checkoutPage.IsCheckOoutCompleate(), Is.True, "The checkout was not completed");
        }
    }
}

