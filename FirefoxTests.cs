using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using static BookingProject.DriverType;

namespace BookingProject
{
    [TestFixture]
    public class FirefoxTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            BrowserFactory browserFactory = new BrowserFactory();
            driver = browserFactory.GetDriver(DriverTypes.Firefox);
        }

        [Test]
        public void FireFoxTestLimerick1Day2Adult1RoomSauna()
        {

            driver.Navigate().GoToUrl(SiteConsts.site);

            SearchResults searchResults = new SearchResults(driver);
            IWebElement searchbox = searchResults.getSearchbox();
            searchbox.SendKeys("Limerick");

            // choose the 1 night stay in 3 months
            IWebElement checkIn3rd = searchResults.getcheckinOn3rdDate();
            checkIn3rd.SendKeys(Keys.Tab);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);

            SelectElement datePick = searchResults.getDateCheckinMonthday();
            datePick.SelectByIndex(3);

            // pick 2 adults
            IWebElement people = searchResults.getPeople();
            people.Click();

            // pick 1 room
            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();

            // after page loads
            // choose a filter - sauna

            IWebElement sauna = searchResults.getSauna();
            sauna.Click();

            // if the filter worked there is only 8 hotel in limerick with saunas
            // its a bit slow to load the result

            IWebElement textForCount = searchResults.gettextForCount();
            Console.WriteLine(textForCount.Text);

            bool result = driver.PageSource.Contains("Greenhills Hotel Limerick");

            Assert.IsTrue(result);
        }

        [Test]
        public void FirefoxTestGeorgeLimerickHotelDoesntHaveASauna()
        {
            driver.Navigate().GoToUrl(SiteConsts.site);

            SearchResults searchResults = new SearchResults(driver);
            IWebElement searchbox = searchResults.getSearchbox();
            searchbox.SendKeys("Limerick");

            // choose the 1 night stay in 3 months
            IWebElement checkIn3rd = searchResults.getcheckinOn3rdDate();
            checkIn3rd.SendKeys(Keys.Tab);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);

            SelectElement datePick = searchResults.getDateCheckinMonthday();
            datePick.SelectByIndex(3);

            // pick 2 adults
            IWebElement people = searchResults.getPeople();
            people.Click();

            // pick 1 room
            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();

            // after page loads
            // choose a filter - sauna

            IWebElement sauna = searchResults.getSauna();
            sauna.Click();

            // its a bit slow to load the result

            IWebElement textForCount = searchResults.gettextForCount();
            Console.WriteLine(textForCount.Text);

            bool result = driver.PageSource.Contains("George Limerick Hotel");

            Assert.IsFalse(result);
        }

        [Test]
        public void FirefoxTestLimerick1Day2Adult1Room5Star()
        {
            driver.Navigate().GoToUrl(SiteConsts.site);

            SearchResults searchResults = new SearchResults(driver);
            IWebElement searchbox = searchResults.getSearchbox();
            searchbox.SendKeys("Limerick");

            // choose the 1 night stay in 3 months
            IWebElement checkIn3rd = searchResults.getcheckinOn3rdDate();
            checkIn3rd.SendKeys(Keys.Tab);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);

            SelectElement datePick = searchResults.getDateCheckinMonthday();
            datePick.SelectByIndex(3);

            // 2 adults
            IWebElement people = searchResults.getPeople();
            people.Click();

            // 1 room
            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();

            // after page loads
            // choose a filter - 5 stars

            IWebElement fiveStar = searchResults.get5Stars();
            fiveStar.Click();

            // if the filter worked there is only one 5 star hotel in limerick
            // takes a while for the page to load, and waiting for the text isn't enough
            Thread.Sleep(5000);

            IWebElement textForCount = searchResults.gettextForCount();
            Console.WriteLine("Number of Results" + textForCount.Text);

            bool result = driver.PageSource.Contains("The Savoy Hotel");
            Assert.IsTrue(result);
        }

        [Test]
        public void FirefoxTestTheGeorgeHotelIsNot5Star()
        {
            driver.Navigate().GoToUrl(SiteConsts.site);

            SearchResults searchResults = new SearchResults(driver);
            IWebElement searchbox = searchResults.getSearchbox();
            searchbox.SendKeys("Limerick");

            // choose the 1 night stay in 3 months
            IWebElement checkIn3rd = searchResults.getcheckinOn3rdDate();
            checkIn3rd.SendKeys(Keys.Tab);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);

            SelectElement datePick = searchResults.getDateCheckinMonthday();
            datePick.SelectByIndex(3);

            // 2 adults
            IWebElement people = searchResults.getPeople();
            people.Click();

            // 1 room
            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();

            // after page loads
            // choose a filter - 5 stars

            IWebElement fiveStar = searchResults.get5Stars();
            fiveStar.Click();

            // if the filter worked there is only one 5 star hotel in limerick
            // takes a while for the page to load, and waiting for the text isn't enough
            Thread.Sleep(5000);

            IWebElement textForCount = searchResults.gettextForCount();
            Console.WriteLine("Number of Results" + textForCount.Text);

            bool result = driver.PageSource.Contains("George Limerick Hotel");
            Assert.IsFalse(result);
        }

        [TearDown]
        public void TearDown()
        {
            BrowserFactory browserFactory = new BrowserFactory();
            browserFactory.closeWebDriver(driver);
        }
    }
}
