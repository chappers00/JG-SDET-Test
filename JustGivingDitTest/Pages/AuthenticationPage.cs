using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace JustGivingDitTest.Pages
{
    class AuthenticationPage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        private static By SectionIdentifier = By.Id("Authentication");

        public AuthenticationPage(IWebDriver browser) : base(browser, SectionIdentifier)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "Authentication_Password")]
        public IWebElement Password { get; set; }

        /// <summary>
        /// Type a password into the box
        /// </summary>
        /// <param name="password">String</param>
        public void enterPassword(String password)
        {
            TypeInElement(Password, password);
        }
    }
}
