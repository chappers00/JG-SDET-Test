using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace JustGivingDitTest.Pages
{
    /// <summary>
    /// Class to represent the Payment page of the Just Giving demo app
    /// </summary>
    class PaymentPage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        private static By SectionIdentifier = By.Id("Payment");

        public PaymentPage(IWebDriver browser) : base(browser, SectionIdentifier)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "Payment_CardType")]
        public IWebElement CardType { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_CardNumber")]
        public IWebElement CardNumber { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_ExpiryDatePart_Month")]
        public IWebElement ExpiryMonth { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_ExpiryDatePart_Year")]
        public IWebElement ExpiryYear { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_NameOnCard")]
        public IWebElement NameOnCard { get; set; }

        /// <summary>
        /// Fill out all the card details for a payment
        /// </summary>
        /// <param name="cardType">Can be any of the parment types in the drop down</param>
        /// <param name="cardNumber"></param>
        /// <param name="expMonth"></param>
        /// <param name="expYear"></param>
        /// <param name="nameOnCard"></param>
        public void enterPaymentDetails(string cardType, string cardNumber, string expMonth, string expYear, string nameOnCard)
        {
            new SelectElement(CardType).SelectByText(cardType);
            TypeInElement(CardNumber, cardNumber);
            new SelectElement(ExpiryMonth).SelectByText(expMonth);
            new SelectElement(ExpiryYear).SelectByText(expYear);
            TypeInElement(NameOnCard, nameOnCard);
        }
    }
}
