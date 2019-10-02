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
        SeleneElement inputMessage = S("#new-message");
        SeleneElement referralMessage = S(".col-xs-12.message");
        SeleneElement sendButton = S("#send-button");
        SeleneElement backButton = S("span#back-link");
        internal static bool isDisplayed;

        public ReferralsSentPage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        internal ReferralsSentPage WriteMessage(string note)
        {
            inputMessage.Hover().SendKeys(note);
            return this;
        }

        internal ReferralsSentPage DisplayMessage()
        {
            WaitFor(S("#message-card-content"), Be.Visible);
            return this;
        }

        internal ReferralsSentPage OpenMessage(string serviceMessage)
        {
            referralMessage.Hover().Click();
            return new ReferralsSentPage(DriverContext);
        }

        internal ReferralsSentPage SendMessage()
        {
            sendButton.Click();
            return new ReferralsSentPage(DriverContext);

        }

        internal ReferralsSentPage GoBack()
        {
            backButton.Hover().Click();
            return new ReferralsSentPage(DriverContext);
        }

        internal ReferralsSentPage VerifyPage()
        {
            String expectedPage = S(By.XPath("//div[@class='col-xs-2']")).GetText();
            String actualPage = "Referrals";
            Assert.AreEqual(expectedPage, actualPage);
            return new ReferralsSentPage(DriverContext);
        }
    }
  }

    

