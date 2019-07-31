using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace BookingProject
{
    [TestFixture]
    public class EdgeTests
    {
        IWebDriver driver;
        readonly string path = @"C:\Code\Webdriver";
        string site = @"https://www.booking.com/";

        [SetUp]
        public void SetUp()
        {
            EdgeOptions options = new EdgeOptions();
            driver = new EdgeDriver(path, options, new TimeSpan(0, 0, 5));
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void EdgeTestBookingDotCom()
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
