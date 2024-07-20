using System;
namespace POM_Exercise.Tests
{
	public class HiddenMenuTests:BaseTest
	{
        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");
            
        }

        [Test]
		public void TestOpenMenu()
		{
			hiddenMenuPage.ClickMenuButton();
			Assert.That(hiddenMenuPage.IsMenuOpen(), Is.True,"The hidden menu was not open");
		}

        [Test]
        public void TestLogOut()
        {
            hiddenMenuPage.ClickMenuButton();
            hiddenMenuPage.ClickLogOutButton();
            Assert.That(loginPage.IsLoginPageOpen(), Is.True,"User was not logged out");
        }

    }
}

