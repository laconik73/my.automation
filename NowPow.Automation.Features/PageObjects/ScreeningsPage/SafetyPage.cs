using System;
using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSelene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class SafetyPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        
        public SafetyPage(DriverContext driverContext) : base(driverContext)
        {
            
        }

        internal SafetyPage SubmitSafety()
        {
            String expectedSectionHeader = S(By.XPath("//h3[contains(text(),'Safety')]")).GetText();
            String actualSectionHeader = "Safety";
            Assert.AreEqual(expectedSectionHeader, actualSectionHeader);
            return this;
        }

        internal BackgroundPage Next()
        {
            S("#next").Click();
            return new BackgroundPage(DriverContext);
        }
    }
}