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
using Nowpow.Automation.Features.StepDefinitions;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class TabsNavigationPage : ProjectPageBase

    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement patientTab = S("[data-link*='patients'][type]");


        public TabsNavigationPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        internal PatientCardsPage OpenPatient(string tabName)
        {
            //patientTab = MenuIsCollapsed ? S("#navbar-collapse #nav-item-patients") : S(".inset-nav #nav-item-patients");
            //ClickNavigationLink(patientTab);
            //WaitFor(S("#count-top"), Be.Visible);
            patientTab.Click();
            return new PatientCardsPage(DriverContext);
        }
    }
}
