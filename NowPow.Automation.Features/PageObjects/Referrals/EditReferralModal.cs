using System;
using NLog;
using NowPow.Automation.PageObjects;
using Ocaramba;
using NSelene;
using OpenQA.Selenium;
using static NSelene.Selene;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Nowpow.Automation.Features.StepDefinitions
{
    public class EditReferralModal : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        SeleneElement acceptanceStatus = S("#acceptanceStatusContainer");
        SeleneElement contactStatusContainer = S("[data-id='contactStatus']");
        SeleneElement saveButton = S("#btn-save");
        SeleneElement accepted = S(By.XPath("//li[@data-original-index='1'] /a/span[text()='Accepted']"));
        SeleneElement waitlist = S(By.XPath("//li[@data-original-index='3'] /a/span[text()='Waitlist']"));
        SeleneElement denied = S(By.XPath("//li[@data-original-index='2'] /a/span[text()='Denied']"));


        public EditReferralModal(DriverContext driverContext) : base(driverContext)
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        internal EditReferralModal SelectAcceptanceStatus(string acceptanceName)
        {
            acceptanceStatus.Click();
            WaitFor(accepted, Be.InDom).Hover().Click();     
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

        internal EditReferralModal SelectAcceptanceStatus()
        {
            try
            {
                acceptanceStatus.Hover().Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("another element is clicked");
            }            
           
            try
            {
                WaitFor(accepted, Be.InDom).Hover().Click();
            }
            catch(Exception e)
            {
                Console.WriteLine("clicks outside of modal");
            }
            

            return this;
        }

        internal ReferralsReceivedPage SaveAcceptedReferral()
        {
            WaitForNot(S(".modal.modal-card.fade.in"), Be.Selected);
            WaitFor(saveButton, Be.Enabled).Hover().Click();
            return new ReferralsReceivedPage(DriverContext);
        }

        internal EditReferralModal SelectWaitlisted(string waitlisted)
        {
            try
            {
                acceptanceStatus.Hover().Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("another element is clicked");
            }

            try
            {
                WaitFor(waitlist, Be.InDom).Hover().Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("clicks outside of modal");
            }
            return this;
        }
    }
}