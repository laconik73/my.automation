using Ocaramba;
using static NSelene.Selene;
using OpenQA.Selenium;
using NSelene;
using NowPow.Automation.PageObjects;
using NLog;
using System;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class NotificationsPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement entryContainer = S("div.entry-container");
        public NotificationsPage(DriverContext driverContext) : base(driverContext)
        {
            
        }

        internal ReferralsReceivedPage ChooseUnreadNotification()
        {
            WaitForNot(S("div.overlay"), Be.InDom);
            entryContainer.Click();
            return new ReferralsReceivedPage(DriverContext);
        }
    }
}