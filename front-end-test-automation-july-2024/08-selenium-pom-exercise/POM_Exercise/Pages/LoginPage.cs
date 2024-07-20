using System;
using OpenQA.Selenium;

namespace POM_Exercise.Pages
{
	public class LoginPage:BasePage
	{
		public LoginPage(IWebDriver driver) : base(driver)
		{
		}
		private readonly By usernameField = By.Id("user-name");
		private readonly By passwordField = By.Id("password");
		private readonly By loginButton = By.Id("login-button");
		private readonly By errorMsg = By.XPath("//div[@class='error-message-container error']");

		public void InputUsername(string username)
		{
			Type(usernameField, username);
		}

		public void InputPassword(string password)
		{
			Type(passwordField, password);
		}

		public void ClickLoginButton()
		{
			Click(loginButton);
		}

		public string GetErrorMessage()
		{
			return GetText(errorMsg);
		}

		public void LoginUser(string username,string password)
		{
			InputUsername(username);
			InputPassword(password);
			ClickLoginButton();
		}

        public bool IsLoginPageOpen()
        {
            return driver.Url.Contains("https://www.saucedemo.com/");
        }
    }
}

