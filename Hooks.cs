using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnitTestProject1
{
    [Binding]
    public class Hooks
    {
        public IWebDriver driver;

        public Hooks(IWebDriver Driver)
        {
            driver = Driver;
        }

        [AfterScenario]
        public void CloseDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
