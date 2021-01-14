using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;


namespace AutomationTask
{
    public class Tests
    {
        String test_url = "https://dotnetfiddle.net/";
        IWebDriver driver;
        WebDriverWait wait;
        HomePageObjects homePageObjects = new HomePageObjects();

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(test_url);
            
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null) driver.Close();
        }

        [Test]
        public void Test1()
        {
            HomePageObjects homePageObjects = new HomePageObjects();

            IWebElement element = wait.Until(driver => driver.FindElement(homePageObjects.RunButton));
            element.Click();

            IWebElement ele = driver.FindElement(homePageObjects.Output);
            Assert.AreEqual("Hello World", ele.Text);
        }

        [Test]
        public void Test2()
        {
            var element = wait.Until(driver => driver.FindElement(By.CssSelector(".nuget-panel input.new-package")));
            element.SendKeys("nUnit");

            var nunitElement = wait.Until(drv => drv.FindElement(By.CssSelector("#menu > li:nth-child(1)")));

            nunitElement.Click();
            // wait for the ul drop down to be visible
            var level2Dropdown = wait.Until(driver => driver.FindElement(By.CssSelector("#menu > li:nth-child(1) > ul")));

            var options = level2Dropdown.FindElements(By.CssSelector("li"));

            foreach(var o in options)
            {
                if (o.Text.Equals("3.12.0"))
                {
                    Assert.True(null != o.FindElement(By.CssSelector("i.glyphicon.glyphicon-ok-sign")));
                    break;
                }
            }
        }
  
    }
}