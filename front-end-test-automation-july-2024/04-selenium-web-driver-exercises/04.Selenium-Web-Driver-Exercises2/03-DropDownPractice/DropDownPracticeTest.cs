using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace _03_DropDownPractice;

public class DropDownPractice
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void DropDownPracticeTest()
    {
        string path = Directory.GetCurrentDirectory() + "/manifacturer.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//form[@name='manufacturers']//select")));
        //IList<IWebElement> allManufacturers = manufacturerDropDown.Options;
        IList<IWebElement> options = dropdown.Options;
        List<string> optionsAsString = new List<string>();


        foreach (var option in options)
        {
            optionsAsString.Add(option.Text);
        }
        optionsAsString.RemoveAt(0);

        foreach (var option in optionsAsString)
        {
            dropdown = new SelectElement(driver.FindElement(By.XPath("//form[@name='manufacturers']//select")));
            dropdown.SelectByText(option);
            if (driver.PageSource.Contains("There are no products available in this category."))
            {
                File.AppendAllText(path, $"The manufacturer {option} has no products");
            }
            else
            {
                //create table element
                IWebElement productTable = driver.FindElement(By.ClassName("productListingData"));

                //fetch all table rows
                File.AppendAllText(path, $"\n\nThe manufacturer {option} products are listet--\n");
                ReadOnlyCollection<IWebElement> rows = productTable.FindElements(By.XPath("//tbody/tr"));

                //print the products info in the file
                foreach (IWebElement row in rows)
                {
                    File.AppendAllText(path, row.Text + "\n");
                }
            }

        }
    }
}
