using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using JustGivingDitTest.Utils;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace JustGivingDitTest.Pages
{
    public partial class BasePage
    {
        /// <summary>
        /// Enum DurationType
        /// </summary>
        public enum DurationType { Millisecond, Second, Minute }

        /// <summary>
        /// The default time to wait for elements to be present
        /// </summary>
        public int defaultWait = 5;

        /// <summary>
        /// Used by the isSectionDisplayedMethod to work out if a section is displayed
        /// </summary>
        private By pageIdentifier;

        /// <summary>
        /// The web driver
        /// </summary>
        private IWebDriver webDriver;
        private Actions actions;

        /// <summary>
        /// Gets or sets the web driver.
        /// </summary>
        /// <value>The web driver.</value>
        public IWebDriver WebDriver
        {
            get { return webDriver; }
            set { webDriver = value; PageFactory.InitElements(value, this); }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public virtual string CurrentUrl { get; set; }

        public BasePage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class.
        /// </summary>
        /// <param name="WebDriver">The web driver.</param>
        /// <param name="Selector">A way of knowing if the right page is shown</param>
        public BasePage(OpenQA.Selenium.IWebDriver WebDriver, By Selector)
        {
            this.WebDriver = WebDriver;
            this.actions = new Actions(WebDriver);
            this.pageIdentifier = Selector;
        }
        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>IWebElement.</returns>
        public IWebElement GetElement(string elementName)
        {
            IWebElement element = FindElement(elementName);
            if (element == null)
            {
                throw new SpecFlowSeleniumException("No element named \"" + elementName + "\" have been found in html page. You should check the accessor.");
            }

            return element;
        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>IWebElement.</returns>
        /// <exception cref="System.NotImplementedException">Not Implemented</exception>
        protected virtual IWebElement FindElement(string elementName)
        {
            throw new NotImplementedException("Not Implemented");
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>List of IWebElement.</returns>
        public List<IWebElement> GetElements(string elementName)
        {
            List<IWebElement> element = FindElements(elementName);
            if (element == null)
            {
                throw new SpecFlowSeleniumException("No element named \"" + elementName + "\" have been found in html page. You should check the accessor.");
            }

            return element;
        }

        /// <summary>
        /// Finds the elements.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>IWebElement.</returns>
        /// <exception cref="System.NotImplementedException">Not Implemented</exception>
        protected virtual List<IWebElement> FindElements(string elementName)
        {
            throw new NotImplementedException("Not Implemented");
        }

        /// <summary>
        /// Waits the specified duration.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="duration">The duration.</param>
        internal void Wait(DurationType durationType, int duration)
        {
            switch (durationType)
            {
                case DurationType.Millisecond:
                    System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(duration));
                    break;
                case DurationType.Second:
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(duration));
                    break;
                case DurationType.Minute:
                    System.Threading.Thread.Sleep(TimeSpan.FromMinutes(duration));
                    break;
            }
        }

        /// <summary>
        /// Changes page.
        /// </summary>
        /// <typeparam name="T">Type of the new Page</typeparam>
        /// <param name="driver">The driver.</param>
        /// <param name="page">The page.</param>
        /// <returns>The new page.</returns>
        public T ChangePage<T>(string page) where T : IBasePage
        {
            string urlBeforeClick = WebDriver.Url;
            WebDriver.Navigate().GoToUrl(page);
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(3d));
            wait.Until((d) => d.Url != urlBeforeClick);
            IBasePage newPage = (IBasePage)Activator.CreateInstance<T>();
            newPage.WebDriver = WebDriver;
            CurrentUrl = page;
            return (T)newPage;
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="urlAlias">The URL alias.</param>
        /// <returns>No page.</returns>
        public virtual string GetUrl(string urlAlias)
        {
            return string.Empty;
        }

        /// <summary>
        /// Hovers the specified element name.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        internal void Hover(string elementName)
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(GetElement(elementName)).Build().Perform();
            Wait(DurationType.Second, 2);
        }

        /// <summary>
        /// Clicks the specified element name.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        internal void Click(string elementName)
        {
            GetElement(elementName).Click();
        }

        /// <summary>
        /// Scrolls to WebElement.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        internal void ScrollTo(string elementName)
        {
            IWebElement element = GetElement(elementName);
            (WebDriver as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
        }

        /// <summary>
        /// Scrolls to WebElement.
        /// </summary>
        /// <param name="element">The element.</param>
        internal void ScrollTo(IWebElement element)
        {
            (WebDriver as IJavaScriptExecutor).ExecuteScript(string.Format("window.scrollTo(0, {0});", element.Location.Y));
        }

        /// <summary>
        /// Selects all (Ctrl+a).
        /// </summary>
        internal void SelectAll()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Copies selected value (Ctrl+c)
        /// </summary>
        internal void Copy()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Pastes clipboard (Ctrl+v)
        /// </summary>
        internal void Paste()
        {
            Actions copy = new Actions(WebDriver);
            copy.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control);
            copy.Build().Perform();
        }

        /// <summary>
        /// Fills the form.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="valueName">Name of the value.</param>
        internal void FillForm(TechTalk.SpecFlow.Table table, string fieldName, string valueName)
        {
            if (table.Rows == null || (table.Rows != null && table.Rows.Count == 0))
                throw new SpecFlowSeleniumException("Table row shouldn't be null or empty");
            foreach (var row in table.Rows)
            {
                GetElement(row[fieldName]).SendKeys(row[valueName]);
            }
        }

        /// <summary>
        /// Evals the script.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="script">The script.</param>
        /// <returns>``0.</returns>
        internal T EvalScript<T>(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            return (T)js.ExecuteScript(script);
        }

        /// <summary>
        /// Runs the script.
        /// </summary>
        /// <param name="script">The script.</param>
        internal void RunScript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript(script);
        }

        /// <summary>
        /// Wait for the defaultWait period for an element to be visible
        /// </summary>
        /// <param name="element">The Web Element to look for</param>
        /// <returns>Returns true when the element is present, false if the element is not displayed by the end of the timeout</returns>
        public bool isElementVisible(IWebElement element)
        {
            int times = defaultWait;
            while (times > 0)
            {
                if (element.Displayed) { return true; }
                Wait(DurationType.Second, 1);
                --times;
            }
            return false;
        }

        /// <summary>
        /// Asserts that this page is displayed
        /// </summary>
        public void pageDisplayed()
        {
            Assert.True(isElementVisible(this.webDriver.FindElement(this.pageIdentifier)), "Section is not visible, using selector {0}", this.pageIdentifier);
        }

        public void TypeInElement(IWebElement element, string keys)
        {
            Assert.True(isElementVisible(element), "Element isn't visible {0}", element);
            element.SendKeys(keys);
        }
    }
}
