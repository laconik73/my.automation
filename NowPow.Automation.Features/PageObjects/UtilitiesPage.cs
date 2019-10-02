using System;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class UtilitiesPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        
        public UtilitiesPage(DriverContext driverContext) : base(driverContext)
        {
            
        }

        internal UtilitiesPage SubmitUtilities()
        {
            String expectedSectionHeader = S(By.XPath("//h3[contains(text(),'Utilities')]")).GetText();
            String actualSectionHeader = "Utilities";
            Assert.AreEqual(expectedSectionHeader, actualSectionHeader);
            return this;
        }

        internal SafetyPage Next()
        {
            S("#next").Click();
            return new SafetyPage(DriverContext);
        }
    }
}