using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace JustGivingDitTest.Pages
{
    /// <summary>
    /// Class to represent the Payment Billing page of the Just Giving demo app
    /// </summary>
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

        /// <summary>
        /// Enter the address details manually. Note currently doesn't use the PostCode lookup
        /// </summary>
        /// <param name="country"></param>
        /// <param name="houseNumber"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="town"></param>
        /// <param name="county"></param>
        /// <param name="postcode"></param>
        public void enterAddressDetails(string country, string houseNumber, string address1, string address2, string town, string county, string postcode)
        {
            new SelectElement(AddressSelector).SelectByText(country);
            //Wait a second to allow the postcode bit to appear
            Wait(DurationType.Second, 1);
            //Postcode lookup only seems to come up for certain countries (just UK?), if it does switch to manual entry
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
