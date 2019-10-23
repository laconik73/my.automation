using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using static NSelene.Selene;
using OpenQA.Selenium;
using System;
using NLog;

namespace Nowpow.Automation.Features.StepDefinitions
{
    internal class ReferralsReceivedPage: ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement taskViewSubNav = S("#tasks");
        SeleneElement referralMessage = S(".message.right");
        SeleneElement inputMessage = S("#new-message");
        SeleneElement sendButton = S("#send-button");

        public ReferralsReceivedPage(DriverContext driverContext): base(driverContext)
        {
            
        }

        internal ReferralsReceivedPage OpenTaskView(string subNav)
        {
            taskViewSubNav.Click();
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage ClickMessage()
        {
            referralMessage.Click();
            return new ReferralsReceivedPage(DriverContext);
        }

        internal ReferralsReceivedPage WriteMessage(string note)
        {
            inputMessage.Hover().SendKeys(note);
            return this;
        }

        internal ReferralsReceivedPage SendMessage()
        {
            WaitForNot(spinner, Be.InDom);
            sendButton.Click();
            return this;
        }
    }
}