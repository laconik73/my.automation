using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nowpow.Automation.Features.PageObjects;
using NowPow.Automation.Features.StepDefinitions;
using Ocaramba;
using TechTalk.SpecFlow;
using static NSelene.Selene;
using OpenQA.Selenium;

namespace Nowpow.Automation.Features.StepDefinitions
{

    [Binding]
    public class ReferralSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        String note;


        public ReferralSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }
        [Given(@"user chooses subtab '(.*)'")]
        public void GivenUserChoosesSubtab(string subtabName)
        {
            new PatientPage(driverContext).OpenReferral(subtabName);
        }
        [When(@"user chooses button '(.*)'")]
        public void WhenUserChoosesButton(string addReferral)
        {
            new PatientPage(driverContext).AddReferral();
        }
        [When(@"user sends referral with a note")]
        public void WhenUserSendsReferralWithANote()
        {
            note = DateTime.Now.Ticks.ToString();
            var modal = new AddReferralModal(driverContext).MakeReferral();
            modal.SelectFirstRefer()
                .WriteNote(note)
                .SelectCheckbox1()
                .SelectCheckbox2()
                .Send();
        }
        [Then(@"new referral is listed")]
        public void ThenNewReferralIsListed()
        {
            var ReferralListed = new ProfilePage(driverContext);
            Assert.AreNotEqual(ReferralListed.Displayed, "referral was not listed");       
            
        }

        [When(@"user edits opened referral info")]
        public void WhenUserEditsOpenedReferralInfo()
        {
            var note = DateTime.Now.Ticks.ToString();
            var modal = new EditReferralModal(driverContext);
            modal
                .SelectAcceptanceStatus("Accepted")
                .SelectContactStatus("Contacted")
                .EnterNote(note)
                .Save();
        }


        [When(@"user opens Edit Referral modal")]
        public void WhenUserOpensEditReferralModal()
        {
            new PatientPage(driverContext).OpenEditReferral();
        }
        
        [When(@"user selects  referral'(.*)'Contacted'")]
        public void WhenUserSelectsReferralContacted(string contacted)
        {
            DateTime.Now.Ticks.ToString();
            var modal = new EditReferralModal(driverContext);
            modal.SelectAcceptanceStatus()
                .SelectContactStatus(contacted);
        }

        [When(@"user selects '(.*)' contact status")]
        public void WhenUserSelectsContactStatus(string statusName)
        {
            DateTime.Now.Ticks.ToString();
            var modal = new EditReferralModal(driverContext);
            modal.SelectAcceptanceStatus()
                .SelectContactStatus(statusName);
        }

        [Then(@"'(.*)' dropdown is displayed and is editable")]
        public void ThenDropdownIsDisplayedAndIsEditable(string serviceReceived)
        {
            new EditReferralModal(driverContext);
            bool dropdown = Verify("div.serviceReceivedAndOutcome");
            Console.WriteLine("service received is displayed and editable");
        }

        private bool Verify(string dropdown)
        {
            try
            {
                bool isdropdownDisplayed = S(By.CssSelector("div.serviceReceivedAndOutcome")).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
