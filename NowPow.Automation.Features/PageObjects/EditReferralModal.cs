using System;
using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using OpenQA.Selenium;
using static NSelene.Selene;
using Ocaramba.WebElements;

namespace Nowpow.Automation.Features.StepDefinitions
{
    public class EditReferralModal : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();
        SeleneElement acceptanceStatusContainer = S("#acceptanceStatusContainer>div");
        SeleneElement contactStatusContainer = S("#contactStatusContainer>div");
        


        public EditReferralModal(DriverContext driverContext) : base(driverContext)
        {

        }
        internal EditReferralModal SelectAcceptanceStatus(string statusName)
        {
            acceptanceStatusContainer.Click();
            Select acceptances = new Select(S("div.btn-group.bootstrap-select.open ul"));
            acceptances.SelectByIndex(1);
            return this;
        }

        internal EditReferralModal SelectContactStatus(string statusName)
        {
            contactStatusContainer.Click();
            Select contacts = new Select(S("div.btn-group.bootstrap-select.open ul"));
            contacts.SelectByText(statusName);
            return this;
        }

        internal object EnterNote(string note)
        {
            throw new NotImplementedException();
        }


        //internal EditReferralModal SelectContactStatus(string contacted)
        //{
        //    contactStatusContainer.Click();
        //    Select contacts = new Select(S("div.btn-group.bootstrap-select.open ul"));
        //    contacts.SelectByIndex(2);
        //    return this;
        //}
    }
}