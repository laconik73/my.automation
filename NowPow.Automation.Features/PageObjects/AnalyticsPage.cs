using System.Threading;
using NLog;
using NSelene;
using NowPow.Automation.PageObjects;
using OpenQA.Selenium;
using static NSelene.Selene;
using Ocaramba;
using System;
using Nowpow.Automation.Features.PageObjects;
using Nowpow.Automation.Features.StepDefinitions;

namespace NowPow.Automation.Features.StepDefinitions
{
    internal class AnalyticsPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement nowpowLogo = S("#nav-home");

        public AnalyticsPage(DriverContext driverContext) : base(driverContext)
        {
            
        }

        internal DashboardPage ClickOnLogo(string logo)
        {
            nowpowLogo.Click();
            return new DashboardPage(DriverContext);
        }
    }
}