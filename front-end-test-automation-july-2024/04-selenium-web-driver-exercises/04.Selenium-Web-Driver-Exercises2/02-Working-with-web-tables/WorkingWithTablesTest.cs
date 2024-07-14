using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace _02_Working_with_web_tables;

public class WorkingWithTables
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
    public void WorkingWithTablesTest()
    {
        IWebElement productsTable = driver.FindElement(By.XPath("//div[@class='contentText']//table"));
        ReadOnlyCollection <IWebElement> tableRows=productsTable.FindElements(By.XPath("//tbody/tr"));

        string path = System.IO.Directory.GetCurrentDirectory() + "/productInfo.csv";
        if (File.Exists(path))
            File.Delete(path);

        foreach (var trow in tableRows)
        {
            ReadOnlyCollection<IWebElement> tableCols = trow.FindElements(By.XPath("td"));
            foreach (var tCol in tableCols)
            {
                //extract product name and cost
                string data = tCol.Text;
                string[] productInfo = data.Split('\n');
                string printProductInfo = productInfo[0].Trim() + "," + productInfo[1].Trim() + "\n";

                //write product info extracted to the file
                File.AppendAllText(path, printProductInfo);
            }
        }
        Assert.IsTrue(File.Exists(path), "CSV file was not created");
        Assert.IsTrue(new FileInfo(path).Length > 0, "CSV file is empty");
    }
}
