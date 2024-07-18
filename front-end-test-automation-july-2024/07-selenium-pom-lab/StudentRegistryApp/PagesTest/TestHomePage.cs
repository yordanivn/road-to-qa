using System;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentRegistryApp.Pages;

namespace StudentRegistryApp.PagesTest
{
	public class TestHomePage:BaseTest
	{
		[Test]
		public void Test_HomePage_Content()
		{
			var page = new HomePage(driver);
			page.Open();
            Assert.That(page.GetTitle(), Is.EqualTo("MVC Example"));
			Assert.That(page.GetPageHedingText(), Is.EqualTo("Students Registry"));
			page.StudnetsCount();
		}

		[Test]
		public void Test_HomePage_Links()
		{
			var homePage = new HomePage(driver);
            homePage.Open();
			homePage.LinkHomePage.Click();
			Assert.IsTrue(new HomePage(driver).IsOpen());

			homePage.Open();
			homePage.LinkAddStudent.Click();
			Assert.IsTrue(new AddStudent(driver).IsOpen());

			homePage.Open();
			homePage.LinkViewStudentPage.Click();
			Assert.IsTrue(new ViewStudents(driver).IsOpen());

		} 
    }
}

