using System;
using NLog;
using NSelene;
using static NSelene.Selene;
using Ocaramba;
using NowPow.Automation.PageObjects;
using Nowpow.Automation.Features.PageObjects;


namespace NowPow.Automation.Features.StepDefinitions

{
    public class ProfilePage : ProjectPageBase
    {  
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement needsButton = S("#needs");
        SeleneElement referralsButton = S("#referrals");
        SeleneElement searchTextbox = S("#services-search-query");

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
               
    }
}

