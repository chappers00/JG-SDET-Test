using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace JustGivingDitTest.Pages
{
    /// <summary>
    /// Contains methods and actions which are common to one or more JG page
    /// </summary>
    class CommonPage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        /// <summary>
        /// Initialise the page
        /// </summary>
        /// <param name="browser">The web driver being used</param>
        public CommonPage(IWebDriver browser)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "heading-title")]
        public IWebElement PageHeading { get; set; }

        public static By ContinueButtonSelector = By.CssSelector(".awesome-continue-button");

        /// <summary>
        /// Locate and press the continue button
        /// </summary>
        public void Continue()
        {
            //Look through all the continue buttons
            //TODO: there's probably a better CSS selector to use for the active button
            var buttons = this.driver.FindElements(ContinueButtonSelector);
            foreach (var b in buttons)
            {
                if(b.Displayed) {b.SendKeys(Keys.Enter); break; }
            }
        }

        /// <summary>
        /// Gets the element containing the page header and validates it matches the input String
        /// </summary>
        /// <param name="header">The expected page header</param>
        public void validateHeader(String header)
        {
            Assert.AreEqual(header, PageHeading.Text, "Page heading doesn't match expected");
        }
    }
}
