using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace JustGivingDitTest.Pages
{
    /// <summary>
    /// Class to represent the Identity page of the Just Giving demo app
    /// </summary>
    class IdentityPage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        private static By SectionIdentifier = By.Id("Identity");

        public IdentityPage(IWebDriver browser) : base(browser, SectionIdentifier)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "donation-message")]
        public IWebElement DonationMessage { get; set; }

        [FindsBy(How = How.ClassName, Using = "sponsor-name")]
        public IWebElement DonationSponsorName { get; set; }

        [FindsBy(How = How.ClassName, Using = "date")]
        public IWebElement DonationDate { get; set; }

        [FindsBy(How = How.ClassName, Using = "donation-amount")]
        public IWebElement DonationAmount { get; set; }

        [FindsBy(How = How.Id, Using = "Identity_EmailAddress")]
        public IWebElement EmailAddress { get; set; }

        /// <summary>
        /// Validate the "donor"
        /// </summary>
        /// <param name="donator">String</param>
        public void validateDonator(String donator)
        {
            Assert.True(DonationSponsorName.Text.Contains(donator), "Donation sponsor {0} doesn't contain expected value {1}", DonationSponsorName.Text, donator);
        }

        /// <summary>
        /// Validate the donation message
        /// </summary>
        /// <param name="message">String</param>
        public void validateMessage(String message)
        {
            Assert.True(DonationMessage.Text.Contains(message), "Donation message {0} doesn't contain expected value {1}", DonationMessage.Text, message);
        }

        /// <summary>
        /// Validate that the donation amount is displayed correctly
        /// </summary>
        /// <param name="amount">String (include the currency symbol)</param>
        public void validateAmount(String amount)
        {
            Assert.True(DonationAmount.Text.Contains(amount), "Donation amount {0} doesn't contain expected value {1}", DonationAmount.Text, amount);
        }

        /// <summary>
        /// Type an email address into the "Your email address" box
        /// </summary>
        /// <param name="address">String</param>
        public void enterEmailAddress(String address)
        {
            TypeInElement(EmailAddress, address);
        }
    }
}
