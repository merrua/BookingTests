using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingProject
{

    public class SearchResults
    {
        IWebDriver driver;

        public SearchResults(IWebDriver Driver)
        {
            driver = Driver;
        }

        // add the various page elements here

        public IWebElement getSearchbox()
        {
            IWebElement searchbox = driver.FindElement(By.CssSelector("#ss"));
            return searchbox;
        }

        public IWebElement getcheckinDate()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(x => x.FindElement(By.CssSelector(".xp__dates__checkin > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > span:nth-child(1)")));
        }

        public IWebElement getcheckinOn3rdDate()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(x => x.FindElement(By.CssSelector(".xp__dates__checkin > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > select:nth-child(2)")));
        }

        public IWebElement getcheckinDate2()
        {
            return driver.FindElement(By.CssSelector("#frm > div.xp__fieldset.accommodation > div.xp__dates.xp__group > div.xp-calendar > div > div > div.bui-calendar__content > div:nth-child(2) > table > tbody > tr:nth-child(2) > td:nth-child(5)"));
        }

        public IWebElement getPeople()
        {
            return driver.FindElement(By.CssSelector("#xp__guests__toggle"));
        }

        public IWebElement getSubmitButton()
        {
            return driver.FindElement(By.CssSelector(".sb-searchbox-submit-col.-submit-button > button"));
        }

        public IWebElement getSauna()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(x => x.FindElement(By.CssSelector("#filter_popular_activities > div:nth-child(2) > a:nth-child(3) > div:nth-child(2) > span:nth-child(1)")));
        }

        public IWebElement get5Stars()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(x => x.FindElement(By.CssSelector("#filter_class > div:nth-child(2) > a:nth-child(3) > div:nth-child(2) > span:nth-child(1)")));
        }

        public IWebElement gettextForCount()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait.Until(x => x.FindElement(By.CssSelector(".sr_header > h1:nth-child(1)")));
        }

        public SelectElement getDateCheckinMonthday()
        {
           return new SelectElement(driver.FindElement(By.Name("checkin_monthday")));
        }
    }
}
