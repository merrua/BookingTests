using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace BookingProject
{
    [TestFixture]
    public class BrowserTests
    {
        IWebDriver driver;
        string path = @"C:\Code\Webdriver";
        string site = @"https://www.booking.com/";

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("-no-remote");
            driver = new ChromeDriver(path, options, new TimeSpan(0, 0, 5));
            driver.Manage().Window.Maximize();
        }


        [Test]
        public void ChromeTestBookingDotComSkipPopup()
        {

            driver.Navigate().GoToUrl(site);
            IWebElement layout = driver.FindElement(By.CssSelector(".bui-button__text"));
            layout.Click();

            Assert.IsNotNull(driver.Title);

        }


        [Test]
        public void ChromeTestBookingDotComSearchFiltersSpa()
        {

            driver.Navigate().GoToUrl(site);
            IWebElement searchbox = driver.FindElement(By.CssSelector("#ss"));
            searchbox.SendKeys("Limerick");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
            submitButton.Click();

            IWebElement facilitiesTitle = driver.FindElement(By.CssSelector("#filter_facilities > div.filtercategory.icon_filtercategory_container > h3"));
            Assert.AreEqual(facilitiesTitle.Text, "Facilities");

        }

        [Test]
        public void ChromeLongFormStarRating()
        {

            driver.Navigate().GoToUrl(site);
            IWebElement searchbox = driver.FindElement(By.CssSelector("#ss"));
            searchbox.SendKeys("Limerick");

            // choose the 3 months
            //IWebElement date = driver.FindElement(By.CssSelector(".xp__dates__checkin > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > span:nth-child(1)"));
            //date.Click();

            SelectElement select = new SelectElement(driver.FindElement(By.CssSelector(".xp__dates__checkin > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > select:nth-child(2)")));


            // 2 adults
            //IWebElement ppl = driver.FindElement(By.CssSelector("#xp_guests_count"));

            // 1 room

            //IWebElement submitButton = driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
            //submitButton.Click();

            ////IWebElement star1 = driver.FindElement(By.CssSelector("#filter_class > div.filteroptions > a:nth-child(1) > input[type='checkbox'] > div"));
            //IWebElement star1B = driver.FindElement(By.CssSelector(".active > div:nth-child(2)"));
            //star1B.Click();


            //Assert.AreNotEqual(star1B.Selected, "star 1 is not selected");
        }


        [Test]
        public void ChromeTestBookingDotComSearchFilters5Stars()
        {

            driver.Navigate().GoToUrl(site);
            IWebElement searchbox = driver.FindElement(By.CssSelector("#ss"));
            searchbox.SendKeys("Limerick");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
            submitButton.Click();

            IList<IWebElement> elements = new List<IWebElement>();
            foreach (var item in driver.FindElements(By.CssSelector("input[type='checkbox']")))
            {
                elements.Add(item);
            }

            Assert.AreNotEqual(elements.Count, 0);
        }

        [Test]
        public void ChromeTestBookingDotComSearchFiltersTitle5Stars()
        {

            driver.Navigate().GoToUrl(site);
            IWebElement searchbox = driver.FindElement(By.CssSelector("#ss"));
            searchbox.SendKeys("Limerick");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
            submitButton.Click();

            IWebElement StarTitle = driver.FindElement(By.CssSelector("h3.filtercategory-title"));
            Assert.AreEqual(StarTitle.Text, "Star Rating");

        }

        [Test]
        public void ChromeTestBookingDotComSearchForLimerick()
        {

            driver.Navigate().GoToUrl(site);
            IWebElement searchbox = driver.FindElement(By.CssSelector("#ss"));
            searchbox.SendKeys("Limerick");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
            submitButton.Click();

            string title = driver.Title;
            bool result = title.Contains("Limerick");
            Assert.IsTrue(result, title);
        }

        [Test]
        public void ChromeAllyTestBookingDotCom()
        {

            driver.Navigate().GoToUrl(site);
            IWebElement layout = driver.FindElement(By.CssSelector(".a11y-skip-to-content"));
            layout.Click();

            Assert.IsNotNull(driver.Title);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
