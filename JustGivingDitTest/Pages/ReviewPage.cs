using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace JustGivingDitTest.Pages
{
    /// <summary>
    /// Class to represent the Review and Donate page of the Just Giving demo app
    /// </summary>
    class ReviewPage : BasePage
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;

        private static By SectionIdentifier = By.Id("ReviewAndDonate");

        public ReviewPage(IWebDriver browser) : base(browser, SectionIdentifier)
        {
            this.driver = browser;
            this.actions = new Actions(browser);
            PageFactory.InitElements(browser, this);
        }
    }
}
