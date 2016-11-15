using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace JustGivingDitTest.Pages
{
    class PaymentBillingPage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        private static By SectionIdentifier = By.Id("Payment_BillingAddress");

        public PaymentBillingPage(IWebDriver browser) : base(browser, SectionIdentifier)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "Payment_BillingAddress_Country")]
        public IWebElement AddressSelector { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_BillingAddress_HouseNumber")]
        public IWebElement HouseNumber { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_BillingAddress_AddressLine1")]
        public IWebElement Address1 { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_BillingAddress_AddressLine2")]
        public IWebElement Address2 { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_BillingAddress_Town")]
        public IWebElement Town { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_BillingAddress_County")]
        public IWebElement County { get; set; }

        [FindsBy(How = How.Id, Using = "Payment_BillingAddress_Postcode")]
        public IWebElement Postcode { get; set; }

        [FindsBy(How = How.ClassName, Using = "manually-enter-address-button")]
        public IWebElement ManualAddressButton { get; set; }


        public void enterAddressDetails(string country, string houseNumber, string address1, string address2, string town, string county, string postcode)
        {
            new SelectElement(AddressSelector).SelectByText(country);
            if(isElementVisible(ManualAddressButton))
            {
                ManualAddressButton.Click();
            }
            TypeInElement(HouseNumber, houseNumber);
            TypeInElement(Address1, address1);
            TypeInElement(Address2, address2);
            TypeInElement(Town, town);
            TypeInElement(County, county);
            TypeInElement(Postcode, postcode);
        }
    }
}
