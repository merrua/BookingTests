using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BookingProject
{
    [TestFixture]
    public class FirefoxTests
    {
        IWebDriver driver;
        string path = @"C:\Code\Webdriver";
        string site = @"https://www.booking.com/";

        [SetUp]
        public void SetUp()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation= @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.AddArguments("-no-remote");
            driver = new FirefoxDriver(path, options, new TimeSpan(0, 0, 15));
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void FireFoxTestBookingDotCom()
        {

            driver.Navigate().GoToUrl(site);
            Assert.IsNotNull(driver.Title);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
