using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;
using System;

namespace Tests.PageObjects
{
    public class QALoginPage
    {
        private readonly IWebDriver _driver;

        public QALoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "user_email")]
        public IWebElement UserEmailEntry { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement UserPasswordEntry { get; set; }

        [FindsBy(How = How.Id, Using = "user_remember_me")]
        public IWebElement UserRememberMe { get; set; }

        [FindsBy(How = How.Id, Using = "btn-signin")]
        public IWebElement UserSubmitButton { get; set; }

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

        public void QALoginAttempt(string baseUrl)
        {

            _driver.Navigate().GoToUrl(baseUrl);
            UserEmailEntry.Click();
            UserEmailEntry.Clear();
            UserEmailEntry.SendKeys("gopalt@ymail.com");
            UserPasswordEntry.Click();
            UserPasswordEntry.Clear();
            UserPasswordEntry.SendKeys("test123");

            UserRememberMe.Click();
            UserSubmitButton.Click();

            //LoginButton.Click();
        }

        //public void LoginAsNobody(string baseUrl)
        //{
        //    _driver.Navigate().GoToUrl(baseUrl);
        //    UserEmailEntry.Click();
        //    UserEmailEntry.Clear();
        //    // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
        //    UserEmailEntry.SendKeys("nobody");

        //    UserRememberMe.Clear();
        //    UserRememberMe.SendKeys("blah");

        //    LoginButton.Click();
        //}
    }
}

