using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BookingProject
{
    [Binding]
    public sealed class BookingSteps
    {
        IWebDriver driver;

        public BookingSteps(IWebDriver Driver)
        {
            driver = Driver;
        }

        [Given(@"I go to the BookingDotCom main page")]
        public void GivenIGoToTheBookingDotComMainPage()
        {
            driver.Navigate().GoToUrl(SiteConsts.site);
        }

        [Given(@"I search for the text '(.*)'")]
        public void GivenISearchForTheText(string text)
        {
            SearchResults searchResults = new SearchResults(driver);
            IWebElement searchbox = searchResults.getSearchbox();
            searchbox.SendKeys("Limerick");
        }

        [Given(@"I choose (.*) night stay in (.*) months")]
        public void GivenIChooseNightStayInMonths(int p0, int p1)
        {
            SearchResults searchResults = new SearchResults(driver);
            IWebElement checkIn3rd = searchResults.getcheckinOn3rdDate();
            checkIn3rd.SendKeys(Keys.Tab);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            checkIn3rd.SendKeys(Keys.ArrowDown);
            SelectElement datePick = searchResults.getDateCheckinMonthday();
            datePick.SelectByIndex(3);
        }

        [Given(@"I pick (.*) adult")]
        [Given(@"I pick (.*) adults")]
        public void GivenIPickAdults(int count)
        {
            if (count == 1)
            {
                SearchResults searchResults = new SearchResults(driver);
                IWebElement people = searchResults.getPeople();
                people.SendKeys(Keys.Tab);
                people.SendKeys(Keys.Tab);
                people.SendKeys(Keys.ArrowDown);
            }
            else if (count == 2)
            {
                SearchResults searchResults = new SearchResults(driver);
                IWebElement people = searchResults.getPeople();
                people.Click();
            }
            else
            {
                Console.WriteLine("add support for more than two people");
            }
        }

        [Given(@"I pick (.*) room")]
        public void GivenIPickRoom(int count)
        {
            SearchResults searchResults = new SearchResults(driver);
            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();
        }

        [When(@"I click on the submit button")]
        public void WhenIClickOnTheSubmitButton()
        {
            SearchResults searchResults = new SearchResults(driver);
            IWebElement submitButton = searchResults.getSubmitButton();
            submitButton.Click();
        }

        [When(@"I select the sauna filter")]
        public void WhenISelectTheSaunaFilter()
        {
            SearchResults searchResults = new SearchResults(driver);
            IWebElement sauna = searchResults.getSauna();
            sauna.Click();
        }

        [Then(@"I see the Facilities text")]
        public void ThenISeeTheFacilitiesText()
        {
            IWebElement facilitiesTitle = driver.FindElement(By.CssSelector("#filter_facilities > div.filtercategory.icon_filtercategory_container > h3"));
            Assert.AreEqual(facilitiesTitle.Text, "Facilities");
        }

        [Then(@"the '(.*)' hotel is in the results")]
        public void ThenTheHotelIsInTheResults(string hotelName)
        {
            SearchResults searchResults = new SearchResults(driver);
            IWebElement textForCount = searchResults.gettextForCount();
            Console.WriteLine(textForCount.Text);

            bool result = driver.PageSource.Contains(hotelName);

            Assert.IsTrue(result);
        }

        [Then(@"we expect '(.*)' '(is|is not)' in the results")]
        public void ThenWeExpectInTheResults(string searchText, string status)
        {
            // replace with check for search ending.
            Thread.Sleep(5000);

            bool result = driver.PageSource.Contains(searchText);
            if (status.ToLower() == "is")
                Assert.IsTrue(result);
            else if (status.ToLower() == "is not")
                Assert.IsFalse(result);
            else
                Assert.Fail("invalid result");
        }

        [When(@"I select the five star filter")]
        public void WhenISelectTheFiveStarFilter()
        {
            SearchResults searchResults = new SearchResults(driver);
            IWebElement fiveStar = searchResults.get5Stars();
            fiveStar.Click();
        }

        [Then(@"the page title is '(.*)'")]
        public void ThenThePageTitleIs(string text)
        {
            Assert.AreEqual(text, driver.Title, "title did not match {0}", driver.Title);
        }

        [Then(@"the page title contains '(.*)'")]
        public void ThenThePageTitleContains(string text)
        {
            Assert.IsTrue(driver.Title.Contains(text));
        }
    }
}
