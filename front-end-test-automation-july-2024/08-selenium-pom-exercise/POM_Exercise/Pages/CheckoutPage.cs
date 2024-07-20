using System;
using OpenQA.Selenium;
using POM_Exercise.Pages;

namespace POM_Exercise
{
	public class CheckoutPage:BasePage
	{
		public CheckoutPage(IWebDriver driver):base(driver)
		{
		}
		//try by.id("first-name") etc
		private readonly By firstNameField = By.CssSelector("#first-name");
        private readonly By lastNameField = By.CssSelector("#last-name");
        private readonly By zipCodeField = By.CssSelector("#postal-code");
		private readonly By continueButton = By.CssSelector("#continue");
		private readonly By finishButton = By.Id("finish");
		//private readonly By cancelButton = By.Id("cancel");
		private readonly By completeHeader = By.CssSelector(".complete-header");

		public void EnterFirstName(string firstName)
		{
			Type(firstNameField, firstName);
		}
		public void EnterLastName(string lastName)
		{
			Type(lastNameField, lastName);
		}

		public void EnterZipCode(string zipcode)
		{
			Type(zipCodeField, zipcode);
		}

		public void ClickContinue()
		{
			Click(continueButton);
		}
		public void ClickFinish()
		{
			Click(finishButton);
		}

		public void CheckOutDetails(string firstName,string lastName,string zipcode)
		{
			EnterFirstName(firstName);
			EnterLastName(lastName);
			EnterZipCode(zipcode);
			ClickContinue();
		}
		public bool IsPageOpen()
		{
			return driver.Url.Contains("checkout-step-one.html") || driver.Url.Contains("checkout-step-two.html");
		}
		public bool IsCheckOoutCompleate()
		{
			return GetText(completeHeader) == "Thank you for your order!";

        }
    }
}

