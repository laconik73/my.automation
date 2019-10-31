using System;
using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using OpenQA.Selenium;
using static NSelene.Selene;
using OpenQA.Selenium.Support.UI;


namespace Nowpow.Automation.Features.StepDefinitions
{
    public class EditReferralModal : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement acceptanceStatus = S("#acceptanceStatusContainer");
        SeleneElement contactStatusContainer = S("[data-id='contactStatus']");
        SeleneElement saveButton = S("#btn-save");
        


        public EditReferralModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        internal EditReferralModal SelectAcceptanceStatus(string acceptanceName)
        {
            acceptanceStatus.Click();
            WaitFor(S(By.XPath("//span[contains(text(),'Accepted')]")), Be.InDom).Click();     
            return this;
        }


        internal EditReferralModal SelectContactStatus(string statusName)
        {
            contactStatusContainer.Click();
            S(By.XPath("//span[contains(text(),'Contacted')]")).Click();
            
            return this;
        }        

        internal EditReferralModal EnterNote(string note)
        {
            S("div.col-xs-12.outcome").SendKeys(note);
            return this;
        }

        internal PatientPage Save()
        {
            WaitForNot(S(".modal.modal-card.fade.in"), Be.Selected);
            WaitFor(saveButton, Be.Enabled).Hover().Click();
            return new PatientPage(DriverContext);
        }

        internal EditReferralModal SaveStatus()
        {
            saveButton.Click();
            return this;
        }
    }
}