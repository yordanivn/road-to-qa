using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace IdeaCenter.Tests
{
	public class IdeaCenterTests : BaseTest
	{
		public string lastCreatedIdeaTitle;
		public string lastCreatedIdeaDescription;

		[Test, Order(1)]
		public void CreateIdeaWithInvalidDataTest()
		{
			createIdeaPage.OpenPage();
			createIdeaPage.CreateNewIdea("", "", "");
			createIdeaPage.AssertErrorMessages();
		}

		[Test, Order(2)]
		public void CreateRandomIdeaTest()
		{
			lastCreatedIdeaTitle = "Title" + RandomString(5);
			lastCreatedIdeaDescription = "Description" + RandomString(5);

            createIdeaPage.OpenPage();
			createIdeaPage.CreateNewIdea(lastCreatedIdeaTitle,"",lastCreatedIdeaDescription);

			Assert.That(driver.Url, Is.EqualTo(myIdeasPage.url), "Wrong redicetion");
			Assert.That(myIdeasPage.DesctiptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription));

		}
		[Test,Order(3)]
		public void ViewLastCreatedIdeaTest()
		{
			myIdeasPage.OpenPage();
			myIdeasPage.ViewButtonListIdea.Click();
			Assert.That(ideasReadPage.ideaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle));
            Assert.That(ideasReadPage.ideaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription));

        }
		[Test,Order(4)]
		public void EditLastCreatedIdeaTitleTest()
		{
            myIdeasPage.OpenPage();
			myIdeasPage.EditButtonListIdea.Click();
			string updatedTitle = "Changed Title";
			editIdeaPage.EditIdeaTitle.Clear();
			editIdeaPage.EditIdeaTitle.SendKeys(updatedTitle);
			editIdeaPage.EditIdeaButton.Click();
			myIdeasPage.ViewButtonListIdea.Click();
			Assert.That(ideasReadPage.ideaTitle.Text.Trim(), Is.EqualTo("Changed Title"));   
        }
        [Test, Order(5)]
        public void EditLastCreatedIdeaDescriptionTest()
        {
            myIdeasPage.OpenPage();
            myIdeasPage.EditButtonListIdea.Click();
            string updatedDescription = "Changed Description";

			editIdeaPage.EditIdeaDescription.Clear();
            editIdeaPage.EditIdeaDescription.SendKeys(updatedDescription);
            editIdeaPage.EditIdeaButton.Click();
            myIdeasPage.ViewButtonListIdea.Click();
            Assert.That(ideasReadPage.ideaDescription.Text.Trim(), Is.EqualTo("Changed Description"));
        }
		[Test,Order(6)]
		public void DeleteLastIdeaTest()
		{
            myIdeasPage.OpenPage();
			myIdeasPage.DeleteButtonListIdea.Click();
			bool isIdeaDeleted = myIdeasPage.IdeaCards.All(card => card.Text.Contains(lastCreatedIdeaDescription));
			Assert.IsFalse(isIdeaDeleted);
        }
    }
}

