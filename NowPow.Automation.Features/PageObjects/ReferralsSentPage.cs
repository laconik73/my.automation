using NLog;
using NowPow.Automation.PageObjects;
using NSelene;
using Ocaramba;
using System;
using static NSelene.Selene;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nowpow.Automation.Features.PageObjects
{
    internal class ReferralsSentPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement referralMessage = S("div[class*='message']");
        SeleneElement inputMessage = S("#new-message");        
        SeleneElement sendButton = S("#send-button");
        SeleneElement backButton = S("span#back-link");
        

        public ReferralsSentPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        internal ReferralsSentPage ClickMessage()
        {
            referralMessage.Click();
            return new ReferralsSentPage(DriverContext);
        }

        internal ReferralsSentPage WriteMessage(string note)
        {
            inputMessage.Hover().SendKeys(note);
            return this;
        }

        internal ReferralsSentPage SendMessage()
        {
            WaitForNot(spinner, Be.InDom);
            sendButton.Click();
            return this;
        }

        internal ReferralsSentPage NavigateBack()
        {
            backButton.Click();
            return new ReferralsSentPage(DriverContext);
        }
    }
}
  

    

