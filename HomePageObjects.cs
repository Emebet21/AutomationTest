using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTask
{
    public class HomePageObjects
    {
       
        public By RunButton => By.Id("run-button");

        public By Output => By.XPath("//*[@id='output']");

        public By NuGetTxtBox => By.CssSelector(".nuget - panel input.new- package");

        public By MenuOption => By.CssSelector("#menu > li:nth-child(1)");

        public By VersionList => By.CssSelector("#menu > li:nth-child(1) > ul");

       
    }
}
