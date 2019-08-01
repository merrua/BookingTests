using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookingProject.DriverType;

namespace BookingProject
{
    public class BrowserFactory
    {
        IWebDriver driver;
        string path = @"C:\Code\Webdriver";

        public void closeWebDriver(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public IWebDriver GetDriver(DriverTypes driverTypes)
        {
            if (driverTypes == DriverTypes.Chrome)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("-no-remote");
                driver = new ChromeDriver(path, options, new TimeSpan(0, 0, 10));
                driver.Manage().Window.Maximize();
            }
            else if (driverTypes == DriverTypes.Firefox)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.BrowserExecutableLocation = @"C:\Program Files\Firefox Nightly\firefox.exe";
                options.AddArguments("--no-remote");
                options.AddArguments("--headless");
                driver = new FirefoxDriver(path, options, new TimeSpan(0, 0, 15));
                driver.Manage().Window.Maximize();
            }
            else if (driverTypes == DriverTypes.Edge)
            {
                EdgeOptions options = new EdgeOptions();
                driver = new EdgeDriver(path, options, new TimeSpan(0, 0, 15));
                driver.Manage().Window.Maximize();
            }
            else
            {
                // if the enum was updated but this factory was not then
                // default to chrome since its the most used browser

                ChromeOptions options = new ChromeOptions();
                options.AddArguments("-no-remote");
                driver = new ChromeDriver(path, options, new TimeSpan(0, 0, 10));
                driver.Manage().Window.Maximize();
            }

            return driver;
        }
    }
}
