using System;
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentRegistryApp.Pages;
namespace StudentRegistryApp.PagesTest
{
	public class TestViewStudents : BaseTest
	{
		[Test]
		public void Test_ViewStudentsPage_Content()
		{
			var page = new ViewStudents(driver);
			page.Open();
			Assert.That(page.GetTitle(), Is.EqualTo("Students"));
			Assert.That(page.GetPageHedingText(), Is.EqualTo("Registered Students"));

			var students = page.GetStudnetsList();
			foreach (string st in students)
			{
				Assert.IsTrue(st.IndexOf("(") > 0);
				Assert.IsTrue(st.LastIndexOf(")") == st.Length - 1);
			}
		}
		[Test]
		public void Test_ViewStudentsPage_Links()
		{
            var studentPage = new ViewStudents(driver);
            studentPage.Open();
            studentPage.LinkViewStudentPage.Click();
            Assert.IsTrue(new ViewStudents(driver).IsOpen());

            studentPage.Open();
            studentPage.LinkAddStudent.Click();
            Assert.IsTrue(new AddStudent(driver).IsOpen());

            studentPage.Open();
            studentPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());
        }
	}
}

