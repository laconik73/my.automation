using System;
using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.StepDefinitions;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class LivingSituationPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
       
        
        public LivingSituationPage(DriverContext driverContext) : base(driverContext)
        {
        }

        internal  LivingSituationPage SubmitLivingSituation()
        {
            String expectedSectionHeader = S(By.XPath("//h3[contains(text(),'Living Situation')]")).GetText();
            String actualSectionHeader = "Living Situation";
            Assert.AreEqual(expectedSectionHeader, actualSectionHeader);
            return this;
        }

        internal FoodPage Next()
        {
            S("#next").Click();
            return new FoodPage(DriverContext);
        }
    }
}

