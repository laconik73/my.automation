using System;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using Nowpow.Automation.Features.PageObjects;
using Nowpow.Automation.Features.StepDefinitions;
using System.Linq;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NowPow.Automation.Features.StepDefinitions

{
    public class ProfilePage : ProjectPageBase
    {  
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement needsButton = S("#needs");
        SeleneElement referralsButton = S("#referrals");
        SeleneElement searchTextbox = S("#services-search-query");
        SeleneElement addInteractionButton = S("#add-interaction");
        SeleneElement nowpowLogo = S("#nav-home");
        SeleneElement screeningSummary = S("a[href*='summary']");
        SeleneElement conductScreeningButton = S("#btn-conduct-screening");       
        SeleneElement takeActionButton = S("#btn-takeAction");

        public bool Displayed { get; internal set; }

        public ProfilePage(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }
        internal ProfilePage Needs()
        {
            needsButton.Click();

            return this;
        }
        
        internal AddReferralModal Referrals()
        {
            WaitForNot(S("#sendReferralModal.modal"), Be.Selected);
            WaitFor(referralsButton, Be.Visible);                       
            referralsButton.Click();
            return new AddReferralModal(DriverContext);
        }
       
        internal ProfilePage InputPatientName()
        {
            searchTextbox.SendKeys("sabina");
            return new ProfilePage(DriverContext);
        }

        internal AddInteractionModal AddInteraction()
        {
            addInteractionButton.Click();
            return new AddInteractionModal(DriverContext);
        }

        internal DashboardPage ClickOnNowPow(string logo)
        {
            WaitForNot(S(".modal.modal-card.fade.in"), Be.InDom);
            nowpowLogo.Click();
            return new DashboardPage(DriverContext);
        }

        internal ScreeningErxPage OpenDetails()
        {
            screeningSummary.Click();

            //switching to popup window 
            string newWindowHandle = Driver.WindowHandles.Last();
            var newWindow = Driver.SwitchTo().Window(newWindowHandle);

            return new ScreeningErxPage(DriverContext);
        }

        internal ScreeningPage ConductScreening(string button)
        {
            WaitForNot(smallSpinner, Be.InDom);
            conductScreeningButton.Click();
            return new ScreeningPage(DriverContext);
        }

        internal ProfilePage OpenTakeAction()
        {
           takeActionButton.Click();
            return this;
        }        
    }
}

