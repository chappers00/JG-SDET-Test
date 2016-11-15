using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGivingDitTest.Pages
{
    class MessageAndAmountPage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;
        private readonly string url = @"https://www.justgiving.com/4w350m3/donation/direct/charity/2050";

        public MessageAndAmountPage(IWebDriver browser)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }
        [FindsBy(How = How.Id, Using = "Identity")]
        public IWebElement IdentitySection { get; set; }

        [FindsBy(How = How.Id, Using = "MessageAndAmount")]
        public IWebElement DonateSection { get; set; }

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

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void selectCurrency(String currencyCode)
        {
            new SelectElement(CurrencySelector).SelectByText(currencyCode);
        }

        public void enterAmount(String currencyAmount)
        {
            CurrencyAmount.Clear();
            CurrencyAmount.SendKeys(currencyAmount);
            CurrencyAmount.SendKeys(Keys.Tab);
        }

        public void validateDonator(String donator)
        {
            var donationElement = this.DonationSponsorName;
            Assert.AreEqual("Your name:\r\n"+donator, this.DonationSponsorName.Text, "Donation sponsor doesn't match expected");
        }

        public void validateMessage(String message)
        {
            Assert.AreEqual("Your message:\r\n"+message, this.DonationMessage.Text, "Donation message doesn't match expected");
        }

        public void validateAmount(String amount)
        {
            Assert.AreEqual("Donation amount:\r\n"+amount, this.DonationAmount.Text, "Donation amount doesn't match expected");
        }
    }
}
