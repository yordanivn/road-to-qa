using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StudentRegistryApp.Pages;
namespace StudentRegistryApp.PagesTest
{
	public class TestAddStudent:BaseTest
	{
		[Test]
		public void Test_TestAddStudentPage_Contet()
		{
			var page = new AddStudent(driver);
			page.Open();

			Assert.That(page.GetTitle(), Is.EqualTo("Add Student"));
			Assert.That(page.GetPageHedingText(), Is.EqualTo("Register New Student"));
			Assert.That(page.NameField.Text, Is.EqualTo(""));
            Assert.That(page.EmailField.Text, Is.EqualTo(""));
			Assert.That(page.AddButton.Text, Is.EqualTo("Add"));
        }
		[Test]
		public void Test_TestAddStudentsPage_Links()
		{
            var addStudentPage = new AddStudent(driver);
            addStudentPage.Open();
            addStudentPage.LinkAddStudent.Click();
            Assert.IsTrue(new AddStudent(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            addStudentPage.Open();
            addStudentPage.LinkViewStudentPage.Click();
            Assert.IsTrue(new ViewStudents(driver).IsOpen());
        }
		[Test]
		public void Test_TestAddStudentPage_AddValidStudent()
		{
            var page = new AddStudent(driver);
            page.Open();

			string name = "bat dancho" + DateTime.Now.Ticks;
			string email = "email@" + DateTime.Now.Ticks;
			page.AddStudentForm(name, email);

			ViewStudents viewStudents = new ViewStudents(driver);
			Assert.That(viewStudents.IsOpen(), Is.True);

			var students = viewStudents.GetStudnetsList();

			string newStudentFullString = name + " (" + email + ")";
			Assert.True(students.Contains(newStudentFullString));


        }
        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            var page = new AddStudent(driver);
            page.Open();

            string name = "";
            string email = "";
            page.AddStudentForm(name, email);
            Assert.That(page.IsOpen(), Is.True);

            Assert.That(page.GetErrorMsg(), Is.EqualTo("Cannot add student. Name and email fields are required!"));



        }
    }
}

