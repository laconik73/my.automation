using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class TransportationPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        
        public TransportationPage(DriverContext driverContext) : base(driverContext)
        {
           
        }

        internal TransportationPage SubmitTransportation()
        {
            String expectedSectionHeader = S(By.XPath("//h3[contains(text(),'Transportation')]")).GetText();
            String actualSectionHeader = "Transportation";
            Assert.AreEqual(expectedSectionHeader, actualSectionHeader);
            return this;
        }

        internal UtilitiesPage Next()
        {
            S("#next").Click();
            return new UtilitiesPage(DriverContext);
        }
    }
}