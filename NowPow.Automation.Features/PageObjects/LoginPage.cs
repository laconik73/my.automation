using System;
using System.Globalization;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using Ocaramba.Extensions;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class LoginPage : ProjectPageBase

    { 
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement emailTextbox = S("#inputEmail");
        SeleneElement nextButton = S("#btn-next");
        SeleneElement passwordTextbox = S("#inputPassword");
        SeleneElement signInButton = S("#btn-signin");
        SeleneElement logOutDisplay = S(By.XPath("//h2[contains(text(),'Logged Out')]"));
        

        public LoginPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }         
         // Pre-condition for all test cases
          
        internal LoginPage GoTo()
        {
            var url = BaseConfiguration.GetUrlValue;
            this.Driver.NavigateTo(new Uri(url));
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            return this;
        }
        internal LoginPage EnterEmail(string email)
        {
            emailTextbox.SendKeys(email);
            return this;
        }

        internal LoginPage Submit()
        {
            nextButton.Click();
            return this;
        }

        internal LoginPage EnterPassword(string password)
        {
            passwordTextbox.SendKeys(password);
            return this;
        }
        //After successful login user lands to DashboardPage/main page
        internal DashboardPage SignIn()
        {
            signInButton.Click();
            return new DashboardPage(DriverContext);
        }

        internal LoginPage OpenNewWindow()
        {
            var driver = new ChromeDriver();
            driver.FindElement(By.CssSelector("Body")).SendKeys(Keys.Control + "t");
            

            string newWindowHandle = Driver.WindowHandles.Last();
            var newWindow = Driver.SwitchTo().Window(newWindowHandle);

            driver.Navigate().GoToUrl("https://app-staged.nowpow.com/");

            driver.FindElement(By.Id("inputEmail")).SendKeys("user-automation@stage.org");            
            driver.FindElementById("btn-next").Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("inputPassword")).SendKeys("Test1234");
            driver.FindElementById("btn-signin").Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("Body")).SendKeys(Keys.Control + 'w');
            driver.Close();


            return new LoginPage(DriverContext);
        }
        internal LoginPage SwitchToFirstWindow()
        {
            string originalWindowHandle = Driver.WindowHandles.First();
            var originalWindow = Driver.SwitchTo().Window(originalWindowHandle);                     
            Assert.IsTrue(logOutDisplay.IsDisplayed());          
            
            return new LoginPage(DriverContext);            
        }
       
    }

}


