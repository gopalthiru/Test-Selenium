using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Products")]
        public IWebElement ProductSection { get; set; }

        [FindsBy(How = How.LinkText, Using = "Vacuum cleaners")]
        public IWebElement VaccumCleaners { get; set; }

        //[FindsBy(How = How.Id, Using = "nav__link primary-nav__link js-dropdown-link js-drawer-link primary-nav__accordion-link expanded")]
        //public IWebElement ProductSection { get; set; }

        //[FindsBy(How = How.LinkText, Using = "Vacuum cleaners")]
        //public IWebElement VaccumCleaners { get; set; }

        /// <summary>
        /// JQuery selector example
        /// </summary>
        public IWebElement LoginButton {
            get
            {
                return _driver.FindElementByJQuery("input[name='btnSubmit']");
            }
        }

        public void OpenVaccumCleaners(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            ProductSection.Click();
            ProductSection.Click();
            //// sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            //ProductSection.SendKeys("admin'--");

            VaccumCleaners.Click();
            //VaccumCleaners.SendKeys("blah");

            //LoginButton.Click();
        }

        public void LoginAsNobody(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            ProductSection.Click();
            ProductSection.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            ProductSection.SendKeys("nobody");

            VaccumCleaners.Clear();
            VaccumCleaners.SendKeys("blah");

            LoginButton.Click();
        }
    }
}

