using System;
using OpenQA.Selenium;

namespace POM_Exercise.Tests
{
	public class LoginTests:BaseTest
	{
		[Test]
		public void TestLoginWithValidCredentials()
		{
			Login("standard_user", "secret_sauce");
			Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True,"The inventory page is not loaded after successful login");	
		}

		[Test]
        public void TestLoginWithInvalidCredentials()
        {
            Login("aaa", "secret_sauce");
			string error = loginPage.GetErrorMessage();
			Assert.That(error.Contains("Username and password do not match any user in this service"));
        }
		[Test]
        public void TestLoginWithLockedOutUser()
        {
            Login("locked_out_user", "secret_sauce");
            string error = loginPage.GetErrorMessage();
            Assert.That(error.Contains("Sorry, this user has been locked out."));
        }
        [Test]
        public void TestLoginWithNoUsername()
        {
            Login("", "secret_sauce");
            string error = loginPage.GetErrorMessage();
            Assert.That(error.Contains("Username is required"));
        }
        [Test]
        public void TestLoginWithNoPassword()
        {
            Login("standard_user", "");
            string error = loginPage.GetErrorMessage();
            Assert.That(error.Contains("Password is required"));
        }
    }
}

