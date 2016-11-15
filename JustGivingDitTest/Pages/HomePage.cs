using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace JustGivingDitTest.Pages
{
    class HomePage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;
        private readonly string url = @"https://www.justgiving.com/4w350m3/donation/direct/charity/2050";

        private static By SectionIdentifier = By.Id("MessageAndAmount");

        public HomePage(IWebDriver browser) : base(browser, SectionIdentifier)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "donation-message")]
        public IWebElement DonationMessage { get; set; }

        [FindsBy(How = How.ClassName, Using = "sponsor-name")]
        public IWebElement DonationSponsorName { get; set; }

        [FindsBy(How = How.ClassName, Using = "donation-amount")]
        public IWebElement DonationAmount { get; set; }

        [FindsBy(How = How.Id, Using = "MessageAndAmount_CurrencyCode")]
        public IWebElement CurrencySelector { get; set; }

        [FindsBy(How = How.Id, Using = "MessageAndAmount_Amount")]
        public IWebElement CurrencyAmount { get; set; }

        /// <summary>
        /// Navigate to the homepage specified in url
        /// </summary>
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        /// <summary>
        /// Selects one of the currencies provided
        /// </summary>
        /// <param name="currencyCode">One of the three-letter currency codes in the amount dropdown (GBP/EUR/USD etc)</param>
        public void selectCurrency(String currencyCode)
        {
            new SelectElement(CurrencySelector).SelectByText(currencyCode);
        }

        /// <summary>
        /// Type in an amount into the currency option
        /// </summary>
        /// <param name="currencyAmount">String</param>
        public void enterAmount(String currencyAmount)
        {
            //TODO: Validate the input
            CurrencyAmount.Clear();
            CurrencyAmount.SendKeys(currencyAmount);
            CurrencyAmount.SendKeys(Keys.Tab);
        }
    }
}
