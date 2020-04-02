using System;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NowPow.Automation.Features.StepDefinitions;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class BackgroundPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        
        SeleneElement inputAddress = S("#txtLocation");
        
        public BackgroundPage(DriverContext driverContext) : base(driverContext)
        {
            
        }      

        internal BackgroundPage SubmitBackground()
        {
            String expectedSectionHeader = S(By.XPath("//h3[contains(text(),'Background')]")).GetText();
            String actualSectionHeader = "Background";
            Assert.AreEqual(expectedSectionHeader, actualSectionHeader);
            return this;
        }

        internal BackgroundPage InputAddress(string address)
        {
            inputAddress.Clear();
            inputAddress.SendKeys(address);
            return this;
        }

        internal ScreeningPage Next()
        {
            S("#next").Click();
            return new ScreeningPage(DriverContext);
        }
    }
}