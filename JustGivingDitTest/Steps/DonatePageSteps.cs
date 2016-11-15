using JustGivingDitTest.Features;
using JustGivingDitTest.Pages;
using JustGivingDitTest.Utils;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace JustGivingDitTest.Steps
{
    [Binding]
    public sealed class DonatePageSteps : SeleniumExtender
    {
        DonatePage dp = new DonatePage(WebDriver);

        [Given(@"I have the home page open")]
        public void GivenIHaveTheHomePageOpen()
        {
            dp.Navigate();
        }

        [Then(@"the header should be '(.*)'")]
        public void ThenTheHeaderShouldBe(string p0)
        {
            dp.validateHeader(p0);
        }

        [Given(@"I have changed currency to '(.*)'")]
        public void GivenIHaveChangedCurrencyTo(string p0)
        {
            dp.selectCurrency(p0);
        }

        [Given(@"I have entered an amount of '(.*)'")]
        public void GivenIHaveEnteredAnAmountOf(string p0)
        {
            dp.enterAmount(p0);
        }

        [When(@"I press the continue button")]
        public void WhenIPressTheContinueButton()
        {
            dp.Continue();
        }

        [Then(@"the '(.*)' section is displayed")]
        public void ThenTheSectionIsDisplayed(string p0)
        {
            if (p0.Equals("Donate"))
            {
                dp.sectionVisible(dp.DonateSection);
            }
            else if (p0.Equals("Identity"))
            {
                dp.sectionVisible(dp.IdentitySection);
            }
            else { throw new KeyNotFoundException(String.Format("Don't have a method for this section %s", p0)); }
        }


        [Then(@"a donation by '(.*)' is created with a message of '(.*)' and amount of '(.*)'")]
        public void ThenADonationByIsCreatedWithAMessageOf(string p0, string p1, string p2)
        {
            dp.validateDonator(p0);
            dp.validateMessage(p1);
            dp.validateAmount(p2);
        }
    }
}
