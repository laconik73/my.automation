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
    internal class FoodPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        
        public FoodPage(DriverContext driverContext) : base(driverContext)
        {
           
        }

        internal FoodPage SubmitFood()
        {
            String expectedSectionHeader = S(By.XPath("//h3[contains(text(),'Food')]")).GetText();
            String actualSectionHeader = "Food";
            Assert.AreEqual(expectedSectionHeader, actualSectionHeader);
            return this;
        }

        internal TransportationPage Next()
        {
            S("#next").Click();
            return new TransportationPage(DriverContext);
        }
    }
}