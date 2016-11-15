using JustGivingDitTest.Pages;
using JustGivingDitTest.Utils;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace JustGivingDitTest.Steps
{
    [Binding]
    public sealed class Steps : SeleniumExtender
    {
        //Doing full page model is a bit overkill for this....
        HomePage hp = new HomePage(WebDriver);
        CommonPage cp = new CommonPage(WebDriver);
        IdentityPage ip = new IdentityPage(WebDriver);
        AuthenticationPage ap = new AuthenticationPage(WebDriver);
        PaymentPage pp = new PaymentPage(WebDriver);
        PaymentBillingPage bp = new PaymentBillingPage(WebDriver);
        ReviewPage rp = new ReviewPage(WebDriver);

        [Given(@"I have the home page open")]
        public void GivenIHaveTheHomePageOpen()
        {
            hp.Navigate();
            hp.pageDisplayed();
        }

        [Then(@"the header should be '(.*)'")]
        public void ThenTheHeaderShouldBe(string p0)
        {
            cp.validateHeader(p0);
        }

        [Given(@"I have changed currency to '(.*)'")]
        public void GivenIHaveChangedCurrencyTo(string p0)
        {
            hp.selectCurrency(p0);
        }

        [Given(@"I have entered an amount of '(.*)'")]
        public void GivenIHaveEnteredAnAmountOf(string p0)
        {
            hp.enterAmount(p0);
        }

        [When(@"I press the continue button")]
        public void WhenIPressTheContinueButton()
        {
            cp.Continue();
        }

        [Then(@"the '(.*)' section is displayed")]
        public void ThenTheSectionIsDisplayed(string p0)
        {
            switch(p0)
            {
                case "Donate":
                    hp.pageDisplayed();
                    break;
                case "Identity":
                    ip.pageDisplayed();
                    break;
                case "Authentication":
                    ap.pageDisplayed();
                    break;
                case "Payment":
                    pp.pageDisplayed();
                    break;
                case "Payment_BillingAddress":
                    bp.pageDisplayed();
                    break;
                case "ReviewAndDonate":
                    rp.pageDisplayed();
                    break;
                default:
                    throw new KeyNotFoundException(string.Format("Don't have a method for this section {0}", p0));
            }
        }


        [Then(@"a donation by '(.*)' is created with a message of '(.*)' and amount of '(.*)'")]
        public void ThenADonationByIsCreatedWithAMessageOf(string p0, string p1, string p2)
        {
            ip.validateDonator(p0);
            ip.validateMessage(p1);
            ip.validateAmount(p2);
        }

        [When(@"I enter an email address of '(.*)'")]
        public void WhenIEnterAnEmailAddressOf(string p0)
        {
            ip.enterEmailAddress(p0);
        }

        [When(@"I enter a password of '(.*)'")]
        public void WhenIEnterAPasswordOf(string p0)
        {
            ap.enterPassword(p0);
        }

        [When(@"I pay with a '(.*)' with number '(.*)' expiry '(.*)' '(.*)' and name '(.*)'")]
        public void WhenIPayWithAWithNumberExpiryAndName(string p0, string p1, string p2, string p3, string p4)
        {
            pp.enterPaymentDetails(p0, p1, p2, p3, p4);
        }

        /// <summary>
        /// This method is pretty horrendous, with more time I would do something a bit more elegant:
        /// Either craft some different steps for options with/without the optional address fields
        /// Or enforce the feature file to have 'null's for fields it doesn't use.
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="town"></param>
        /// <param name="country"></param>
        /// <param name="postcode"></param>
        [When(@"I enter billing details of '([^,]+), ([^,]+), ([^,]+), ([^,]+), ([^,]+)'")]
        public void WhenIEnterBillingDetailsOf(string line1, string line2, string town, string postcode, string country)
        {
            bp.enterAddressDetails(country, "", line1, line2, town, "", postcode);
        }


    }
}
