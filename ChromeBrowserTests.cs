using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;
using static BookingProject.DriverType;

namespace BookingProject
{
    [TestFixture]
    public class ChromeBrowserTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            BrowserFactory browserFactory = new BrowserFactory();
            driver = browserFactory.GetDriver(DriverTypes.Chrome);
        }

        [Test]
        public void ChromeTestBookingDotComSearchFiltersSpa()
        {
            driver.Navigate().GoToUrl(SiteConsts.site);

            SearchResults searchResults = new SearchResults(driver);
            IWebElement searchbox = searchResults.getSearchbox();
            searchbox.SendKeys("Limerick");

            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();

            IWebElement facilitiesTitle = driver.FindElement(By.CssSelector("#filter_facilities > div.filtercategory.icon_filtercategory_container > h3"));
            Assert.AreEqual(facilitiesTitle.Text, "Facilities");
        }


        [Test]
        public void ChromeTestLimerick1Day2Adult1RoomSauna()
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
        public void ChromeTestGeorgeLimerickHotelDoesntHaveASauna()
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

            bool result = driver.PageSource.Contains("George Limerick Hotel");

            Assert.IsFalse(result);
        }

        [Test]
        public void ChromeTestLimerick1Day2Adult1Room5Star()
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
        public void ChromeTestTheGeorgeHotelIsNot5Star()
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

        [Test]
        public void ChromeCityInTitle()
        {
            driver.Navigate().GoToUrl(SiteConsts.site);

            SearchResults searchResults = new SearchResults(driver);
            IWebElement searchbox = searchResults.getSearchbox();
            searchbox.SendKeys("Limerick");

            // pick just 1 for a 1 night stay
            IWebElement checkinDate = searchResults.getcheckinDate();
            checkinDate.Click();
            IWebElement checkinDate2 = searchResults.getcheckinDate2();
            checkinDate2.Click();

            // 2 adults
            IWebElement people = searchResults.getPeople();
            people.Click();

            // 1 room
            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();

            string result = driver.Title;
            Assert.IsTrue(result.Contains("Limerick"));
        }

        [Test]
        public void ChromeLimerick1Day1Adult1Room()
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
            IWebElement people = driver.FindElement(By.CssSelector("#xp__guests__toggle"));
            people.Click();
            IWebElement peopleDec = driver.FindElement(By.CssSelector("div.sb-group__field:nth-child(1) > div:nth-child(1) > div:nth-child(2) > button:nth-child(2)"));
            peopleDec.Click();

            // 1 room
            IWebElement submitButton = driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
            submitButton.Click();

            string result = driver.Title;
            Assert.IsTrue(result.Contains("Limerick"));
        }


        [Test]
        public void ChromeTestBookingDotComSearchFilters5Stars()
        {

            driver.Navigate().GoToUrl(SiteConsts.site);
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

            driver.Navigate().GoToUrl(SiteConsts.site);
            IWebElement searchbox = driver.FindElement(By.CssSelector("#ss"));
            searchbox.SendKeys("Limerick");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
            submitButton.Click();

            IWebElement StarTitle = driver.FindElement(By.CssSelector("h3.filtercategory-title"));
            Assert.AreEqual(StarTitle.Text, "Star rating");
        }


        [TearDown]
        public void TearDown()
        {
            BrowserFactory browserFactory = new BrowserFactory();
            browserFactory.closeWebDriver(driver);
        }
    }
}
