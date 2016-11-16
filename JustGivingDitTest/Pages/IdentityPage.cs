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
            var donationElement = this.DonationSponsorName;
            Assert.AreEqual("Your name:\r\n"+donator, DonationSponsorName.Text, "Donation sponsor doesn't match expected");
        }

        /// <summary>
        /// Validate the donation message
        /// </summary>
        /// <param name="message">String</param>
        public void validateMessage(String message)
        {
            Assert.AreEqual("Your message:\r\n"+message, DonationMessage.Text, "Donation message doesn't match expected");
        }

        /// <summary>
        /// Validate that the donation amount is displayed correctly
        /// </summary>
        /// <param name="amount">String (include the currency symbol)</param>
        public void validateAmount(String amount)
        {
            Assert.AreEqual("Donation amount:\r\n"+amount, DonationAmount.Text, "Donation amount doesn't match expected");
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
