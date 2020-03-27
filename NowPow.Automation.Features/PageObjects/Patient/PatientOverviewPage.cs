using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static NSelene.Selene;

namespace Nowpow.Automation.Features.StepDefinitions
{
    public class PatientOverviewPage : ProjectPageBase
    {

        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement screeningSubtab = S(By.Id("screenings"));

        

        public PatientOverviewPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        internal PatientScreeningPage OpenScreenings(string subtabname)
        {
            screeningSubtab.Click();
            return new PatientScreeningPage(DriverContext);
        }
    }
}
