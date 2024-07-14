// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

[TestFixture]
public class 31LoginInvalidUserAndRetryTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void 31LoginInvalidUserAndRetry() {
    // Test name: 3.1_LoginInvalidUserAndRetry
    // Step # | name | target | value
    // 1 | open | / | 
    driver.Navigate().GoToUrl("https://www.saucedemo.com//");
    // 2 | type | css=*[data-test="username"] | user123
    driver.FindElement(By.CssSelector("*[data-test=\"username\"]")).SendKeys("user123");
    // 3 | type | css=*[data-test="password"] | secret_sauce
    driver.FindElement(By.CssSelector("*[data-test=\"password\"]")).SendKeys("secret_sauce");
    // 4 | click | css=*[data-test="login-button"] | 
    driver.FindElement(By.CssSelector("*[data-test=\"login-button\"]")).Click();
    // 5 | storeText | css=*[data-test="error"] | errorMsg
    vars["errorMsg"] = driver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text;
    // 6 | if | ${errorMsg}=== "Epic sadface: Username and password do not match any user in this service" | 
    if ((Boolean) js.ExecuteScript("return (arguments[0]=== \'Epic sadface: Username and password do not match any user in this service\')", vars["errorMsg"])) {
      // 7 | echo | / | Wrong username
      Console.WriteLine("/");
      // 10 | type | css=*[data-test="username"] | standard_user
      driver.FindElement(By.CssSelector("*[data-test=\"username\"]")).SendKeys("standard_user");
      // 11 | type | css=*[data-test="password"] | secret_sauce
      driver.FindElement(By.CssSelector("*[data-test=\"password\"]")).SendKeys("secret_sauce");
      // 12 | click | css=*[data-test="login-button"] | 
      driver.FindElement(By.CssSelector("*[data-test=\"login-button\"]")).Click();
      // 13 | assertText | css=*[data-test="title"] | Products
      Assert.That(driver.FindElement(By.CssSelector("*[data-test=\"title\"]")).Text, Is.EqualTo("Products"));
      // 14 | end |  | 
    }
    // 15 | close |  | 
    driver.Close();
  }
}