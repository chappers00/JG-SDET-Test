using JustGivingDitTest.Pages;
using JustGivingDitTest.Utils;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace JustGivingDitTest.Steps
{
    //TODO: Refactor into steps for each section of the donation process

    [Binding]
    public sealed class Steps : SeleniumExtender
    {
        //Initiate all the different page templates
        //This may be a bit overkill for the demo
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
            //Navigate to the start page
            hp.Navigate();
            //Make sure we got there
            hp.pageDisplayed();
        }

        [Then(@"the header should be '(.*)'")]
        public void ThenTheHeaderShouldBe(string p0)
        {
            //Validate that the page header is as expected
            cp.validateHeader(p0);
        }

        [Given(@"I have entered an amount of '([^']+)' in '([^']+)'")]
        public void GivenIHaveEnteredAnAmountOf(string p0, string p1)
        {
            hp.enterAmount(p0);
            hp.selectCurrency(p1);
            cp.Continue();
        }

        [Then(@"the '(.*)' section is displayed")]
        public void ThenTheSectionIsDisplayed(string p0)
        {
            //TODO: Tidy up / make more efficient
            switch(p0)
            {
                case "Donate":
                    hp.pageDisplayed();
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
            //Make sure the Identity Page is shown
            ip.pageDisplayed();
            //Validate fields in the donation summary
            ip.validateDonator(p0);
            ip.validateMessage(p1);
            ip.validateAmount(p2);
        }

        [When(@"I enter an email address of '(.*)'")]
        public void WhenIEnterAnEmailAddressOf(string p0)
        {
            ip.enterEmailAddress(p0);
            cp.Continue();
        }

        [When(@"I enter a password of '(.*)'")]
        public void WhenIEnterAPasswordOf(string p0)
        {
            ap.enterPassword(p0);
            cp.Continue();
        }

        [When(@"I pay with a '(.*)' with number '(.*)' expiry '(.*)' '(.*)' and name '(.*)'")]
        public void WhenIPayWithAWithNumberExpiryAndName(string p0, string p1, string p2, string p3, string p4)
        {
            //Make sure the payment page is displayed
            pp.pageDisplayed();
            pp.enterPaymentDetails(p0, p1, p2, p3, p4);
            cp.Continue();
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
            bp.pageDisplayed();
            bp.enterAddressDetails(country, "", line1, line2, town, "", postcode);
            cp.Continue();
        }
    }
}
